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

        public SquareSpaceRateLimitException(string message) : base(message) { }

        public SquareSpaceRateLimitException(HttpStatusCode httpStatusCode, string type, string subType, string message, string details) : base(httpStatusCode, type, subType, message, details) { }
    }
}