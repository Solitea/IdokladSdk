using System;
using System.Collections.Generic;
using IdokladSdk.Clients.Interfaces;
using IdokladSdk.Models.StockMovement;
using IdokladSdk.Requests.StockMovement;
using IdokladSdk.Response;

namespace IdokladSdk.Clients
{
    /// <summary>
    /// Client for communication with stock movement endpoints.
    /// </summary>
    public partial class StockMovementClient : BaseClient,
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
        [Obsolete("Use async method instead.")]
        public ApiResult<StockMovementPostModel> Default(int priceListItemId)
        {
            return DefaultAsync(priceListItemId).GetAwaiter().GetResult();
        }

        /// <inheritdoc/>
        [Obsolete("Use async method instead.")]
        public ApiResult<bool> Delete(int id)
        {
            return DeleteAsync(id).GetAwaiter().GetResult();
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
        [Obsolete("Use async method instead.")]
        public ApiResult<StockMovementGetModel> Post(StockMovementPostModel model)
        {
            return PostAsync(model).GetAwaiter().GetResult();
        }

        /// <inheritdoc />
        [Obsolete("Use async method instead.")]
        public ApiBatchResult<StockMovementGetModel> Post(List<StockMovementPostModel> models)
        {
            return PostAsync(models).GetAwaiter().GetResult();
        }

        /// <inheritdoc />
        [Obsolete("Use async method instead.")]
        public ApiResult<StockMovementGetModel> Update(StockMovementPatchModel model)
        {
            return UpdateAsync(model).GetAwaiter().GetResult();
        }
    }
}
