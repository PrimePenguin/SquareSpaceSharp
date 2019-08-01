﻿using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace SquareSpaceSharp.Infrastructure.Policies
{
    /// <summary>
    /// A retry policy that attempts to pro-actively limit the number of requests that will result in a SquareSpaceRateLimitException
    /// by implementing the leaky bucket algorithm.
    /// For example: if 100 requests are created in parallel, only 40 should be immediately sent, and the subsequent 60 requests
    /// should be throttled at 1 per 500ms.
    /// </summary>
    /// <remarks>
    /// In comparison, the naive retry policy will issue the 100 requests immediately:
    /// 60 requests will fail and be retried after 500ms,
    /// 59 requests will fail and be retried after 500ms,
    /// 58 requests will fail and be retried after 500ms.
    /// https://en.wikipedia.org/wiki/Leaky_bucket
    /// </remarks>
    public partial class SmartRetryExecutionPolicy : IRequestExecutionPolicy
    {
        private const string RESPONSE_HEADER_API_CALL_LIMIT = "X-SquareSpace-Shop-Api-Call-Limit";

        private const string REQUEST_HEADER_ACCESS_TOKEN = "X-SquareSpace-Access-Token";

        private static readonly TimeSpan THROTTLE_DELAY = TimeSpan.FromMilliseconds(500);

        private static ConcurrentDictionary<string, LeakyBucket> _shopAccessTokenToLeakyBucket = new ConcurrentDictionary<string, LeakyBucket>();

        public async Task<T> Run<T>(CloneableRequestMessage baseRequest, ExecuteRequestAsync<T> executeRequestAsync)
        {
            var accessToken = GetAccessToken(baseRequest);
            LeakyBucket bucket = null;

            if (accessToken != null)
            {
                bucket = _shopAccessTokenToLeakyBucket.GetOrAdd(accessToken, _ => new LeakyBucket());
            }

            while (true)
            {
                var request = baseRequest.Clone();

                if (accessToken != null)
                {
                    await bucket.GrantAsync();
                }

                try
                {
                    var fullResult = await executeRequestAsync(request);
                    var bucketState = GetBucketState(fullResult.Response);

                    if (bucketState != null)
                    {
                        bucket?.SetState(bucketState);
                    }

                    return fullResult.Result;
                }
                catch (SquareSpaceRateLimitException)
                {
                    //An exception may still occur:
                    //-SquareSpace may have a slightly different algorithm
                    //-SquareSpace may change to a different algorithm in the future
                    //-There may be timing and latency delays
                    //-Multiple programs may use the same access token
                    //-Multiple instances of the same program may use the same access token
                    await Task.Delay(THROTTLE_DELAY);
                }
            }
        }

        private string GetAccessToken(HttpRequestMessage client)
        {
            IEnumerable<string> values = new List<string>();

            return client.Headers.TryGetValues(REQUEST_HEADER_ACCESS_TOKEN, out values) ?
                values.FirstOrDefault() :
                null;
        }

        private LeakyBucketState GetBucketState(HttpResponseMessage response)
        {
            var headers = response.Headers.FirstOrDefault(kvp => kvp.Key == RESPONSE_HEADER_API_CALL_LIMIT);
            var apiCallLimitHeaderValue = headers.Value?.FirstOrDefault();

            if (apiCallLimitHeaderValue != null)
            {
                var split = apiCallLimitHeaderValue.Split('/');
                if (split.Length == 2 &&
                    int.TryParse(split[0], out int currentFillLevel) &&
                    int.TryParse(split[1], out int capacity))
                {
                    return new LeakyBucketState(capacity, currentFillLevel);
                }
            }

            return null;
        }
    }
}