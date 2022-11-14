using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using IdokladSdk.Clients.Interfaces;
using IdokladSdk.Models.StockMovement;
using IdokladSdk.Requests.StockMovement;
using IdokladSdk.Response;

namespace IdokladSdk.Clients
{
    /// <summary>
    /// Client for communication with stock movement endpoints.
    /// </summary>
    public class StockMovementClient : BaseClient,
        IDefaultWithIdRequest<StockMovementPostModel>,
        IDeleteRequest,
        IEntityDetail<StockMovementDetail>,
        IEntityList<StockMovementList>,
        IPatchRequest<StockMovementPatchModel, StockMovementGetModel>,
        IPostRequest<StockMovementPostModel, StockMovementGetModel>,
        IPostBatchRequest<StockMovementPostModel, StockMovementGetModel>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="StockMovementClient" /> class.
        /// </summary>
        /// <param name="apiContext">API context.</param>
        public StockMovementClient(ApiContext apiContext)
            : base(apiContext)
        {
        }

        /// <inheritdoc />
        public override string ResourceUrl { get; } = "/StockMovements";

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

        /// <inheritdoc />
        public StockMovementDetail Detail(int id)
        {
            return new StockMovementDetail(id, this);
        }

        /// <inheritdoc />
        public StockMovementList List()
        {
            return new StockMovementList(this);
        }

        /// <inheritdoc />
        public Task<ApiResult<StockMovementGetModel>> PostAsync(StockMovementPostModel model, CancellationToken cancellationToken = default)
        {
            return PostAsync<StockMovementPostModel, StockMovementGetModel>(model, cancellationToken);
        }

        /// <inheritdoc />
        public Task<ApiBatchResult<StockMovementGetModel>> PostAsync(List<StockMovementPostModel> models, CancellationToken cancellationToken = default)
        {
            return PostAsync<StockMovementPostModel, StockMovementGetModel>(models, cancellationToken);
        }

        /// <inheritdoc />
        public Task<ApiResult<StockMovementGetModel>> UpdateAsync(StockMovementPatchModel model, CancellationToken cancellationToken = default)
        {
            return PatchAsync<StockMovementPatchModel, StockMovementGetModel>(model, cancellationToken);
        }
    }
}
