using System.Threading.Tasks;

namespace SquareSpaceSharp.Infrastructure.Policies
{
    public delegate Task<RequestResult<T>> ExecuteRequestAsync<T>(CloneableRequestMessage request);

    public interface IRequestExecutionPolicy
    {
        Task<T> Run<T>(CloneableRequestMessage requestMessage, ExecuteRequestAsync<T> executeRequestAsync);
    }
}