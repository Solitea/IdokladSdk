using System.Collections.Generic;
using System.Globalization;
using System.Threading;
using System.Threading.Tasks;
using IdokladSdk.Models.Batch;
using IdokladSdk.Models.PriceListItem;
using IdokladSdk.Response;
using RestSharp;

namespace IdokladSdk.Clients
{
    public partial class PriceListItemClient
    {
        /// <inheritdoc/>
        public Task<ApiResult<PriceListItemPostModel>> DefaultAsync(CancellationToken cancellationToken = default)
        {
            return DefaultAsync<PriceListItemPostModel>(cancellationToken);
        }

        /// <inheritdoc cref="Delete(int,bool)"/>
        public Task<ApiResult<bool>> DeleteAsync(int id, bool deleteIfReferenced = true, CancellationToken cancellationToken = default)
        {
            var resource = $"{ResourceUrl}/{id}/{deleteIfReferenced.ToString(CultureInfo.InvariantCulture)}";

            return DeleteAsync<bool>(resource, cancellationToken);
        }

        /// <inheritdoc cref="Delete(List{int},bool)"/>
        public async Task<ApiBatchResult<bool>> DeleteAsync(List<int> idBatch, bool deleteIfReferenced, CancellationToken cancellationToken = default)
        {
            var batch = new BatchModel<int>(idBatch);
            var resource = $"{BatchUrl}/{deleteIfReferenced.ToString(CultureInfo.InvariantCulture)}";
            var request = await CreateRequestAsync(resource, method: Method.DELETE, cancellationToken).ConfigureAwait(false);
            request.AddJsonBody(batch);

            return await ExecuteBatchAsync<bool>(request, cancellationToken).ConfigureAwait(false);
        }

        /// <inheritdoc/>
        public Task<ApiResult<PriceListItemGetModel>> PostAsync(PriceListItemPostModel model, CancellationToken cancellationToken = default)
        {
            return PostAsync<PriceListItemPostModel, PriceListItemGetModel>(model, cancellationToken);
        }

        /// <inheritdoc />
        public Task<ApiBatchResult<PriceListItemGetModel>> PostAsync(List<PriceListItemPostModel> models, CancellationToken cancellationToken = default)
        {
            return PostAsync<PriceListItemPostModel, PriceListItemGetModel>(models, cancellationToken);
        }

        /// <inheritdoc/>
        public Task<ApiResult<PriceListItemGetModel>> UpdateAsync(PriceListItemPatchModel model, CancellationToken cancellationToken = default)
        {
            return PatchAsync<PriceListItemPatchModel, PriceListItemGetModel>(model, cancellationToken);
        }

        /// <inheritdoc/>
        public Task<ApiBatchResult<PriceListItemGetModel>> UpdateAsync(List<PriceListItemPatchModel> models, CancellationToken cancellationToken = default)
        {
            return PatchAsync<PriceListItemPatchModel, PriceListItemGetModel>(models, cancellationToken);
        }
    }
}
