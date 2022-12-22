using System.Collections.Generic;
using System.Globalization;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using IdokladSdk.Clients.Interfaces;
using IdokladSdk.Models.Batch;
using IdokladSdk.Models.PriceListItem;
using IdokladSdk.Requests.Extensions;
using IdokladSdk.Requests.PriceListItem;
using IdokladSdk.Response;

namespace IdokladSdk.Clients
{
    /// <summary>
    /// Client for communication with price list item endpoints.
    /// </summary>
    public class PriceListItemClient : BaseClient,
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
        public Task<ApiResult<PriceListItemPostModel>> DefaultAsync(CancellationToken cancellationToken = default)
        {
            return DefaultAsync<PriceListItemPostModel>(cancellationToken);
        }

        /// <summary>
        /// Deletes entity.
        /// </summary>
        /// <param name="id">Entity id.</param>
        /// <param name="deleteIfReferenced">Indicates whether item referenced on invoices or exported item will be deleted.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns><see cref="ApiResult{TData}"/> instance.</returns>
        public Task<ApiResult<bool>> DeleteAsync(int id, bool deleteIfReferenced = true, CancellationToken cancellationToken = default)
        {
            var resource = $"{ResourceUrl}/{id}/{deleteIfReferenced.ToString(CultureInfo.InvariantCulture)}";

            return DeleteAsync<bool>(resource, cancellationToken);
        }

        /// <summary>
        /// Deletes entities.
        /// </summary>
        /// <param name="idBatch">List of entity ids.</param>
        /// <param name="deleteIfReferenced">Indicates whether items referenced on invoices or exported items will be deleted.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns><see cref="ApiBatchResult{TData}"/> instance.</returns>
        public async Task<ApiBatchResult<bool>> DeleteAsync(List<int> idBatch, bool deleteIfReferenced, CancellationToken cancellationToken = default)
        {
            var batch = new BatchModel<int>(idBatch);
            var resource = $"{BatchUrl}/{deleteIfReferenced.ToString(CultureInfo.InvariantCulture)}";
            var request = await CreateRequestAsync(resource, HttpMethod.Delete, cancellationToken).ConfigureAwait(false);
            request.AddJsonBody(batch);

            return await ExecuteBatchAsync<bool>(request, cancellationToken).ConfigureAwait(false);
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
        public Task<ApiResult<PriceListItemGetModel>> PostAsync(PriceListItemPostModel model, CancellationToken cancellationToken = default)
        {
            return PostAsync<PriceListItemPostModel, PriceListItemGetModel>(model, cancellationToken);
        }

        /// <inheritdoc/>
        public Task<ApiBatchResult<PriceListItemGetModel>> PostAsync(List<PriceListItemPostModel> models, CancellationToken cancellationToken = default)
        {
            return PostAsync<PriceListItemPostModel, PriceListItemGetModel>(models, cancellationToken);
        }

        /// <inheritdoc/>
        public Task<ApiResult<PriceListItemGetModel>> UpdateAsync(PriceListItemPatchModel model, CancellationToken cancellationToken = default)
        {
            return PatchAsync<PriceListItemPatchModel, PriceListItemGetModel>(model, cancellationToken);
        }

        /// <inheritdoc />
        public Task<ApiBatchResult<PriceListItemGetModel>> UpdateAsync(List<PriceListItemPatchModel> models, CancellationToken cancellationToken = default)
        {
            return PatchAsync<PriceListItemPatchModel, PriceListItemGetModel>(models, cancellationToken);
        }
    }
}
