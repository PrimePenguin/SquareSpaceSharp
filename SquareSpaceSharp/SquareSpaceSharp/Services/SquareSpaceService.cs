﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using SquareSpaceSharp.Extensions;
using SquareSpaceSharp.Infrastructure;
using SquareSpaceSharp.Infrastructure.Policies;

namespace SquareSpaceSharp.Services
{
    public abstract class SquareSpaceService
    {
        private static IRequestExecutionPolicy _GlobalExecutionPolicy = new DefaultRequestExecutionPolicy();

        private IRequestExecutionPolicy _ExecutionPolicy;

        private static JsonSerializer _Serializer = Serializer.JsonSerializer;

        private static HttpClient _Client { get; } = new HttpClient();

        protected Uri _ShopUri { get; set; }

        protected string _secretApiKey { get; set; }

        /// <summary>
        /// Creates a new instance of <see cref="SquareSpaceService" />.
        /// </summary>
        /// <param name="secretApiKey">App Secret Api Key</param>
        protected SquareSpaceService(string secretApiKey)
        {
            _ShopUri = BuildSquareSpaceApiUri();
            _secretApiKey = secretApiKey;

            // If there's a global execution policy it should be set as this instance's policy.
            // User can override it with instance-specific execution policy.
            _ExecutionPolicy = _GlobalExecutionPolicy ?? new DefaultRequestExecutionPolicy();
        }

        /// <summary>
        /// Attempts to build a shop API <see cref="Uri"/> for the given shop. Will throw a <see cref="SquareSpaceException"/> if the URL cannot be formatted.
        /// </summary>
        /// <exception cref="SquareSpaceException">Thrown if the given URL cannot be converted into a well-formed URI.</exception>
        /// <returns>The shop's API <see cref="Uri"/>.</returns>
        public static Uri BuildSquareSpaceApiUri()
        {
            return new Uri("https://api.squarespace.com");
        }

        protected RequestUri PrepareRequest(string path)
        {
            return new RequestUri(new Uri($"https://api.squarespace.com/1.0/commerce/{path}"));
        }

        /// <summary>
        /// Prepares a request to the path and appends the shop's access token header if applicable.
        /// </summary>
        protected CloneableRequestMessage PrepareRequestMessage(RequestUri uri, HttpMethod method, HttpContent content = null)
        {
            var msg = new CloneableRequestMessage(uri.ToUri(), method, content);

            if (!string.IsNullOrEmpty(_secretApiKey))
            {
                msg.Headers.Add("Authorization", $"Bearer {_secretApiKey}");
            }

            msg.Headers.Add("Accept", "application/json");
            msg.Headers.Add("user-agent", "SquareSpace");

            return msg;
        }

        /// <summary>
        /// Executes a request and returns the given type. Throws an exception when the response is invalid.
        /// Use this method when the expected response is a single line or simple object that doesn't warrant its own class.
        /// </summary>
        protected async Task<T> ExecuteRequestAsync<T>(RequestUri uri, HttpMethod method, HttpContent content = null, string rootElement = null) where T : new()
        {
            using (var baseRequestMessage = PrepareRequestMessage(uri, method, content))
            {
                var policyResult = await _ExecutionPolicy.Run(baseRequestMessage, async requestMessage =>
                {
                    var request = _Client.SendAsync(requestMessage);

                    using (var response = await request)
                    {
                        var rawResult = await response.Content.ReadAsStringAsync();

                        //Check for and throw exception when necessary.
                        CheckResponseExceptions(response, rawResult);

                        // This method may fail when the method was Delete, which is intendend.
                        // Delete methods should not be parsing the response JSON and should instead
                        // be using the non-generic ExecuteRequestAsync.
                        var reader = new JsonTextReader(new StringReader(rawResult));
                        var data = _Serializer.Deserialize<JObject>(reader);
                        var result = data.ToObject<T>();

                        return new RequestResult<T>(response, result, rawResult);
                    }
                });

                return policyResult;
            }
        }

        /// <summary>
        /// Checks a response for exceptions or invalid status codes. Throws an exception when necessary.
        /// </summary>
        /// <param name="response">The response.</param>
        public static void CheckResponseExceptions(HttpResponseMessage response, string rawResponse)
        {
            int statusCode = (int)response.StatusCode;

            // No error if response was between 200 and 300.
            if (statusCode >= 200 && statusCode < 300)
            {
                return;
            }

            var requestIdHeader = response.Headers.FirstOrDefault(h => h.Key.Equals("X-Request-Id", StringComparison.OrdinalIgnoreCase));
            string requestId = requestIdHeader.Value?.FirstOrDefault();
            var code = response.StatusCode;

            // If the error was caused by reaching the API rate limit, throw a rate limit exception.
            if ((int)code == 429 /* Too many requests */)
            {
                string listMessage = "Exceeded 2 calls per second for api client. Reduce request rates to resume uninterrupted service.";
                string rateLimitMessage = $"Error: {listMessage}";

                // SquareSpace used to return JSON for rate limit exceptions, but then made an unannounced change and started returning HTML.
                // This dictionary is an attempt at preserving what was previously returned.
                var rateLimitErrors = new Dictionary<string, IEnumerable<string>>
                {
                    {"Error", new List<string> {listMessage}}
                };

                throw new SquareSpaceRateLimitException(code, rateLimitErrors, rateLimitMessage, rawResponse, requestId);
            }

            var contentType = response.Content.Headers.GetValues("Content-Type").FirstOrDefault();
            var defaultMessage = $"Response did not indicate success. Status: {(int)code} {response.ReasonPhrase}.";

            if (contentType.StartsWithIgnoreCase("application/json") || contentType.StartsWithIgnoreCase("text/json"))
            {
                var errors = ParseErrorJson(rawResponse);
                string message = defaultMessage;

                if (errors == null)
                {
                    errors = new Dictionary<string, IEnumerable<string>>
                    {
                            {
                                $"{(int)code} {response.ReasonPhrase}",
                                new[] { message }
                            }
                        };
                }
                else
                {
                    var firstError = errors.First();

                    message = $"{firstError.Key}: {string.Join(", ", firstError.Value)}";
                }

                throw new SquareSpaceException(code, errors, message, rawResponse, requestId);
            }
            {
                var errors = new Dictionary<string, IEnumerable<string>>
                {
                    {
                        $"{(int)code} {response.ReasonPhrase}",
                        new[] { defaultMessage }
                    },
                    {
                        "NoJsonError",
                        new[] { "Response did not return JSON, unable to parse error message (if any)." }
                    }
                };

                throw new SquareSpaceException(code, errors, defaultMessage, rawResponse, requestId);
            }
        }

        /// <summary>
        /// Parses a JSON string for square space API errors.
        /// </summary>
        /// <returns>Returns null if the JSON could not be parsed into an error.</returns>
        public static Dictionary<string, IEnumerable<string>> ParseErrorJson(string json)
        {
            if (string.IsNullOrEmpty(json))
            {
                return null;
            }

            var errors = new Dictionary<string, IEnumerable<string>>();

            try
            {
                var parsed = JToken.Parse(string.IsNullOrEmpty(json) ? "{}" : json);

                // Errors can be any of the following:
                // 1. { errors: "some error message"}
                // 2. { errors: { "order" : "some error message" } }
                // 3. { errors: { "order" : [ "some error message" ] } }
                // 4. { error: "invalid_request", error_description:"The authorization code was not found or was already used" }

                if (parsed.Any(p => p.Path == "error") && parsed.Any(p => p.Path == "error_description"))
                {
                    // Error is type #4
                    var description = parsed["error_description"];

                    errors.Add("invalid_request", new List<string> { description.Value<string>() });
                }
                else if (parsed.Any(x => x.Path == "errors"))
                {
                    var parsedErrors = parsed["errors"];

                    //errors can be either a single string, or an array of other errors
                    if (parsedErrors.Type == JTokenType.String)
                    {
                        //errors is type #1

                        errors.Add("Error", new List<string> { parsedErrors.Value<string>() });
                    }
                    else
                    {
                        //errors is type #2 or #3

                        foreach (var val in parsedErrors.Values())
                        {
                            string name = val.Path.Split('.').Last();
                            var list = new List<string>();

                            if (val.Type == JTokenType.String)
                            {
                                list.Add(val.Value<string>());
                            }
                            else if (val.Type == JTokenType.Array)
                            {
                                list = val.Values<string>().ToList();
                            }

                            errors.Add(name, list);
                        }
                    }
                }
                else
                {
                    return null;
                }
            }
            catch (Exception e)
            {
                errors.Add(e.Message, new List<string> { json });
            }

            // KVPs are structs and can never be null. Instead, check if the first error equals the default kvp value.
            if (errors.FirstOrDefault().Equals(default(KeyValuePair<string, IEnumerable<string>>)))
            {
                return null;
            }

            return errors;
        }
    }
}