using System.Threading;
using System.Threading.Tasks;
using IdokladSdk.Response;

namespace IdokladSdk.Clients.Interfaces
{
    /// <summary>
    /// Interface for Copy endpoints.
    /// </summary>
    /// <typeparam name="TCopyModel">Copy model type.</typeparam> name=""/>
    public interface ICopyRequest<TCopyModel>
    {
        /// <summary>
        /// Copies entity.
        /// </summary>
        /// <param name="id">Entity id.</param>
        /// <returns><see cref="ApiResult{TData}"/> instance.</returns>
        ApiResult<TCopyModel> Copy(int id);

        /// <summary>
        /// Copies entity.
        /// </summary>
        /// <param name="id">Entity id.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns><see cref="ApiResult{TData}"/> instance.</returns>
        Task<ApiResult<TCopyModel>> CopyAsync(int id, CancellationToken cancellationToken = default);
    }
}
