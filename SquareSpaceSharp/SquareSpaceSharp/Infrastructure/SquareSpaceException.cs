using System;
using System.Collections.Generic;
using System.Net;

namespace SquareSpaceSharp.Infrastructure
{
    public class SquareSpaceException : Exception
    {
        public HttpStatusCode HttpStatusCode { get; set; }

        /// <summary>
        /// The XRequestId header returned by Wix. Can be used when working with the Wix support team to identify the failed request.
        /// </summary>
        public string RequestId { get; set; }

        /// <remarks>
        /// Dictionary is always initialized to ensure null reference errors won't be thrown when trying to check error messages.
        /// </remarks>
        public Dictionary<string, IEnumerable<string>> Errors { get; set; } = new Dictionary<string, IEnumerable<string>>();

        /// <summary>
        /// The raw JSON string returned by Wix.
        /// </summary>
        public string RawBody { get; set; }

        public SquareSpaceException() { }

        public SquareSpaceException(string message) : base(message) { }

        public SquareSpaceException(HttpStatusCode httpStatusCode, Dictionary<string, IEnumerable<string>> errors, string message, string rawBody, string requestId) : base(message)
        {
            HttpStatusCode = httpStatusCode;
            Errors = errors;
            RawBody = rawBody;
            RequestId = requestId;
        }
    }
}