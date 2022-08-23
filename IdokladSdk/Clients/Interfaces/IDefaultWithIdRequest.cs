using System;
using System.Threading;
using System.Threading.Tasks;
using IdokladSdk.Response;

namespace IdokladSdk.Clients.Interfaces
{
    /// <summary>
    /// Interface for endpoints which returns new entity with default property values for specified document.
    /// </summary>
    /// <typeparam name="TPostModel">POST data type.</typeparam>
    public interface IDefaultWithIdRequest<TPostModel>
    {
        /// <summary>
        /// Returns new default entity suitable for editing and storing for specified document.
        /// </summary>
        /// <param name="id">Entity Id.</param>
        /// <returns><see cref="ApiResult{TData}"/> instance.</returns>
        [Obsolete("Use async method instead.")]
        ApiResult<TPostModel> Default(int id);

        /// <summary>
        /// Returns new default entity suitable for editing and storing for specified document.
        /// </summary>
        /// <param name="id">Entity Id.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns><see cref="ApiResult{TData}"/> instance.</returns>
        Task<ApiResult<TPostModel>> DefaultAsync(int id, CancellationToken cancellationToken = default);
    }
}
