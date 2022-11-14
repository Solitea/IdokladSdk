using System.Threading;
using System.Threading.Tasks;
using IdokladSdk.Response;

namespace IdokladSdk.Clients.Interfaces
{
    /// <summary>
    /// Interface for POST endpoints.
    /// </summary>
    /// <typeparam name="TPostModel">Post model type.</typeparam>
    /// <typeparam name="TGetModel">Get model type.</typeparam>
    public interface IPostRequest<in TPostModel, TGetModel>
        where TPostModel : class
        where TGetModel : new()
    {
        /// <summary>
        /// Posts new entity.
        /// </summary>
        /// <param name="model">Entity to be created.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns><see cref="ApiResult{TData}"/> instance.</returns>
        Task<ApiResult<TGetModel>> PostAsync(TPostModel model, CancellationToken cancellationToken = default);
    }
}
