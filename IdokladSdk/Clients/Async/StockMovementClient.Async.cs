using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using IdokladSdk.Models.StockMovement;
using IdokladSdk.Response;

namespace IdokladSdk.Clients
{
    public partial class StockMovementClient
    {
        /// <inheritdoc/>
        public Task<ApiResult<StockMovementPostModel>> DefaultAsync(int priceListItemId, CancellationToken cancellationToken = default)
        {
            return GetAsync<StockMovementPostModel>(ResourceUrl + $"/Default/{priceListItemId}", null, cancellationToken);
        }

        /// <inheritdoc/>
        public Task<ApiResult<bool>> DeleteAsync(int id, CancellationToken cancellationToken = default)
        {
            return DeleteAsync<bool>(id, cancellationToken);
        }

        /// <inheritdoc/>
        public Task<ApiResult<StockMovementGetModel>> PostAsync(StockMovementPostModel model, CancellationToken cancellationToken = default)
        {
            return PostAsync<StockMovementPostModel, StockMovementGetModel>(model, cancellationToken);
        }

        /// <inheritdoc/>
        public Task<ApiBatchResult<StockMovementGetModel>> PostAsync(List<StockMovementPostModel> models, CancellationToken cancellationToken = default)
        {
            return PostAsync<StockMovementPostModel, StockMovementGetModel>(models, cancellationToken);
        }

        /// <inheritdoc/>
        public Task<ApiResult<StockMovementGetModel>> UpdateAsync(StockMovementPatchModel model, CancellationToken cancellationToken = default)
        {
            return PatchAsync<StockMovementPatchModel, StockMovementGetModel>(model, cancellationToken);
        }
    }
}
