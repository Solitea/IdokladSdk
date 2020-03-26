using System.Collections.Generic;
using System.Globalization;
using IdokladSdk.Clients.Interfaces;
using IdokladSdk.Models.Batch;
using IdokladSdk.Models.PriceListItem;
using IdokladSdk.Requests.PriceListItem;
using IdokladSdk.Response;
using RestSharp;

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
        public ApiResult<PriceListItemPostModel> Default()
        {
            return Default<PriceListItemPostModel>();
        }

        /// <inheritdoc cref="IDeleteRequest.Delete"/>
        /// <param name="id">Entity id.</param>
        /// <param name="deleteIfReferenced">Indicates whether item referenced on invoices or exported item will be deleted.</param>
        public ApiResult<bool> Delete(int id, bool deleteIfReferenced = true)
        {
            var resource = $"{ResourceUrl}/{id}/{deleteIfReferenced.ToString(CultureInfo.InvariantCulture)}";

            return Delete<bool>(resource);
        }

        /// <summary>
        /// Deletes entities.
        /// </summary>
        /// <param name="idBatch">List of entity ids.</param>
        /// <param name="deleteIfReferenced">Indicates whether items referenced on invoices or exported items will be deleted.</param>
        /// <returns><see cref="ApiBatchResult{TData}"/> instance.</returns>
        public ApiBatchResult<bool> Delete(List<int> idBatch, bool deleteIfReferenced)
        {
            var batch = new BatchModel<int>(idBatch);
            var resource = $"{BatchUrl}/{deleteIfReferenced.ToString(CultureInfo.InvariantCulture)}";
            var request = CreateRequest(resource, Method.DELETE);
            request.AddJsonBody(batch);

            return ExecuteBatch<bool>(request);
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
        public ApiResult<PriceListItemGetModel> Post(PriceListItemPostModel model)
        {
            return Post<PriceListItemPostModel, PriceListItemGetModel>(model);
        }

        /// <inheritdoc/>
        public ApiBatchResult<PriceListItemGetModel> Post(List<PriceListItemPostModel> models)
        {
            return Post<PriceListItemPostModel, PriceListItemGetModel>(models);
        }

        /// <inheritdoc/>
        public ApiResult<PriceListItemGetModel> Update(PriceListItemPatchModel model)
        {
            return Patch<PriceListItemPatchModel, PriceListItemGetModel>(model);
        }

        /// <inheritdoc />
        public ApiBatchResult<PriceListItemGetModel> Update(List<PriceListItemPatchModel> models)
        {
            return Patch<PriceListItemPatchModel, PriceListItemGetModel>(models);
        }
    }
}
