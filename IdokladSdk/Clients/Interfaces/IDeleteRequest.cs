using System;
using System.Threading;
using System.Threading.Tasks;
using IdokladSdk.Response;

namespace IdokladSdk.Clients.Interfaces
{
    /// <summary>
    /// Interface for DELETE endpoints.
    /// </summary>
    public interface IDeleteRequest
    {
        /// <summary>
        /// Deletes entity.
        /// </summary>
        /// <param name="id">Entity id.</param>
        /// <returns><see cref="ApiResult{TData}"/> instance.</returns>
        [Obsolete("Use async method instead.")]
        ApiResult<bool> Delete(int id);

        /// <summary>
        /// Deletes entity.
        /// </summary>
        /// <param name="id">Entity id.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns><see cref="ApiResult{TData}"/> instance.</returns>
        Task<ApiResult<bool>> DeleteAsync(int id, CancellationToken cancellationToken = default);
    }
}
