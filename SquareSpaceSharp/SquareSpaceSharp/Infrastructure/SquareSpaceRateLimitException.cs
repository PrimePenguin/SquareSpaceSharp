using System.Collections.Generic;
using System.Net;

namespace SquareSpaceSharp.Infrastructure
{
    /// <summary>
    /// An exception thrown when an API call has reached SquareSpaceSharp's rate limit.
    /// </summary>
    public class SquareSpaceRateLimitException : SquareSpaceException
    {
        public SquareSpaceRateLimitException()
        { }

        public SquareSpaceRateLimitException(string message): base(message) { }

        public SquareSpaceRateLimitException(HttpStatusCode httpStatusCode, Dictionary<string, IEnumerable<string>> errors, string message, string jsonError, string requestId) : base(httpStatusCode, errors, message, jsonError, requestId) { }
    }
}