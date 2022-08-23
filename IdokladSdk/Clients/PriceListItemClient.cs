using System;
using System.Collections.Generic;
using IdokladSdk.Clients.Interfaces;
using IdokladSdk.Models.PriceListItem;
using IdokladSdk.Requests.PriceListItem;
using IdokladSdk.Response;

namespace IdokladSdk.Clients
{
    /// <summary>
    /// Client for communication with price list item endpoints.
    /// </summary>
    public partial class PriceListItemClient : BaseClient,
        IDefaultRequest<PriceListItemPostModel>,
        IEntityDetail<PriceListItemDetail>,
        IEntityList<PriceListItemList>,
        IPatchRequest<PriceListItemPatchModel, PriceListItemGetModel>,
        IPatchBatchRequest<PriceListItemPatchModel, PriceListItemGetModel>,
        IPostRequest<PriceListItemPostModel, PriceListItemGetModel>,
        IPostBatchRequest<PriceListItemPostModel, PriceListItemGetModel>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PriceListItemClient"/> class.
        /// </summary>
        /// <param name="apiContext">API context.</param>
        public PriceListItemClient(ApiContext apiContext)
            : base(apiContext)
        {
        }

        /// <inheritdoc/>
        public override string ResourceUrl { get; } = "/PriceListItems";

        /// <inheritdoc/>
        [Obsolete("Use async method instead.")]
        public ApiResult<PriceListItemPostModel> Default()
        {
            return DefaultAsync().GetAwaiter().GetResult();
        }

        /// <inheritdoc cref="IDeleteRequest.Delete"/>
        /// <param name="id">Entity id.</param>
        /// <param name="deleteIfReferenced">Indicates whether item referenced on invoices or exported item will be deleted.</param>
        [Obsolete("Use async method instead.")]
        public ApiResult<bool> Delete(int id, bool deleteIfReferenced = true)
        {
            return DeleteAsync(id, deleteIfReferenced).GetAwaiter().GetResult();
        }

        /// <summary>
        /// Deletes entities.
        /// </summary>
        /// <param name="idBatch">List of entity ids.</param>
        /// <param name="deleteIfReferenced">Indicates whether items referenced on invoices or exported items will be deleted.</param>
        /// <returns><see cref="ApiBatchResult{TData}"/> instance.</returns>
        [Obsolete("Use async method instead.")]
        public ApiBatchResult<bool> Delete(List<int> idBatch, bool deleteIfReferenced)
        {
            return DeleteAsync(idBatch, deleteIfReferenced).GetAwaiter().GetResult();
        }

        /// <inheritdoc/>
        public PriceListItemDetail Detail(int id)
        {
            return new PriceListItemDetail(id, this);
        }

        /// <inheritdoc/>
        public PriceListItemList List()
        {
            return new PriceListItemList(this);
        }

        /// <inheritdoc/>
        [Obsolete("Use async method instead.")]
        public ApiResult<PriceListItemGetModel> Post(PriceListItemPostModel model)
        {
            return PostAsync(model).GetAwaiter().GetResult();
        }

        /// <inheritdoc/>
        [Obsolete("Use async method instead.")]
        public ApiBatchResult<PriceListItemGetModel> Post(List<PriceListItemPostModel> models)
        {
            return PostAsync(models).GetAwaiter().GetResult();
        }

        /// <inheritdoc/>
        [Obsolete("Use async method instead.")]
        public ApiResult<PriceListItemGetModel> Update(PriceListItemPatchModel model)
        {
            return UpdateAsync(model).GetAwaiter().GetResult();
        }

        /// <inheritdoc />
        [Obsolete("Use async method instead.")]
        public ApiBatchResult<PriceListItemGetModel> Update(List<PriceListItemPatchModel> models)
        {
            return UpdateAsync(models).GetAwaiter().GetResult();
        }
    }
}
