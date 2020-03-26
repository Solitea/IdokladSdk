using System.Threading;
using System.Threading.Tasks;
using IdokladSdk.Response;

namespace IdokladSdk.Clients.Interfaces
{
    /// <summary>
    /// Interface for endpoints which returns new entity with default property values.
    /// </summary>
    /// <typeparam name="TPostModel">POST data type.</typeparam>
    public interface IDefaultRequest<TPostModel>
        where TPostModel : new()
    {
        /// <summary>
        /// Returns new entity with default property values suitable for subsequent editing and storing.
        /// </summary>
        /// <returns><see cref="ApiResult{TData}"/> instance.</returns>
        ApiResult<TPostModel> Default();

        /// <summary>
        /// Returns new entity with default property values suitable for subsequent editing and storing.
        /// </summary>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns><see cref="ApiResult{TData}"/> instance.</returns>
        Task<ApiResult<TPostModel>> DefaultAsync(CancellationToken cancellationToken = default);
    }
}
