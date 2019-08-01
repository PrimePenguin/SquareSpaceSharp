using System;
using System.Threading.Tasks;

namespace SquareSpaceSharp.Infrastructure.Policies
{
    public class RetryExecutionPolicy : IRequestExecutionPolicy
    {
        private static readonly TimeSpan RETRY_DELAY = TimeSpan.FromMilliseconds(500);

        public async Task<T> Run<T>(CloneableRequestMessage baseRequest, ExecuteRequestAsync<T> executeRequestAsync)
        {
            while (true)
            {
                var request = baseRequest.Clone();

                try
                {
                    var fullResult = await executeRequestAsync(request);

                    return fullResult.Result;
                }
                catch (SquareSpaceRateLimitException)
                {
                    await Task.Delay(RETRY_DELAY);
                }
            }
        }
    }
}