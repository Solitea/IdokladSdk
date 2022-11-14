using System.Threading;
using System.Threading.Tasks;
using IdokladSdk.Response;

namespace IdokladSdk.Clients.Interfaces
{
    /// <summary>
    /// Interface for RECOUNT endpoints.
    /// </summary>
    /// <typeparam name="TRecountPostModel">Post model type.</typeparam>
    /// <typeparam name="TGetModel">Get model type.</typeparam>
    public interface IRecountRequest<in TRecountPostModel, TGetModel>
    {
        /// <summary>
        /// Recounts entity.
        /// </summary>
        /// <param name="model">Entity to recount.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns><see cref="ApiResult{TData}"/> instance.</returns>
        Task<ApiResult<TGetModel>> RecountAsync(TRecountPostModel model, CancellationToken cancellationToken = default);
    }
}
