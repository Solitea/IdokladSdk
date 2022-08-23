using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using IdokladSdk.Response;

namespace IdokladSdk.Clients.Interfaces
{
    /// <summary>
    /// Interface for batch PATCH endpoints.
    /// </summary>
    /// <typeparam name="TPatchModel">Patch model type.</typeparam>
    /// <typeparam name="TGetModel">Get model type.</typeparam>
    public interface IPatchBatchRequest<TPatchModel, TGetModel>
        where TPatchModel : class
        where TGetModel : new()
    {
        /// <summary>
        /// Updates entities.
        /// </summary>
        /// <param name="models">List of entities to be updated.</param>
        /// <returns><see cref="ApiBatchResult{TData}"/> instance.</returns>
        [Obsolete("Use async method instead.")]
        ApiBatchResult<TGetModel> Update(List<TPatchModel> models);

        /// <summary>
        /// Updates entities.
        /// </summary>
        /// <param name="models">List of entities to be updated.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns><see cref="ApiBatchResult{TData}"/> instance.</returns>
        Task<ApiBatchResult<TGetModel>> UpdateAsync(List<TPatchModel> models, CancellationToken cancellationToken = default);
    }
}
