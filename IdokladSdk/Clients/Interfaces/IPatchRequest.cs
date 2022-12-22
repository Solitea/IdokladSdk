using System.Threading;
using System.Threading.Tasks;
using IdokladSdk.Response;

namespace IdokladSdk.Clients.Interfaces
{
    /// <summary>
    /// Interface for PATCH endpoints.
    /// </summary>
    /// <typeparam name="TPatchModel">Patch model type.</typeparam>
    /// <typeparam name="TGetModel">Get model type.</typeparam>
    public interface IPatchRequest<in TPatchModel, TGetModel>
    {
        /// <summary>
        /// Updates entity.
        /// </summary>
        /// <param name="model">Updated entity.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns><see cref="ApiResult{T}"/> instance.</returns>
        Task<ApiResult<TGetModel>> UpdateAsync(TPatchModel model, CancellationToken cancellationToken = default);
    }
}
