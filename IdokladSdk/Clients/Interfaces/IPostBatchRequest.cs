using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using IdokladSdk.Response;

namespace IdokladSdk.Clients.Interfaces
{
    /// <summary>
    /// Interface for batch POST endpoints.
    /// </summary>
    /// <typeparam name="TPostModel">Post model type.</typeparam>
    /// <typeparam name="TGetModel">Get model type.</typeparam>
    public interface IPostBatchRequest<TPostModel, TGetModel>
        where TPostModel : class
        where TGetModel : new()
    {
        /// <summary>
        /// Posts new entities.
        /// </summary>
        /// <param name="models">List of entities to be created.</param>
        /// <returns><see cref="ApiBatchResult{TData}"/> instance.</returns>
        [Obsolete("Use async method instead.")]
        ApiBatchResult<TGetModel> Post(List<TPostModel> models);

        /// <summary>
        /// Posts new entities.
        /// </summary>
        /// <param name="models">List of entities to be created.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns><see cref="ApiBatchResult{TData}"/> instance.</returns>
        Task<ApiBatchResult<TGetModel>> PostAsync(List<TPostModel> models, CancellationToken cancellationToken = default);
    }
}
