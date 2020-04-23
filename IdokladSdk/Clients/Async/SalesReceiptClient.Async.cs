using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using IdokladSdk.Models.SalesReceipt;
using IdokladSdk.Response;

namespace IdokladSdk.Clients
{
    public partial class SalesReceiptClient
    {
        /// <inheritdoc />
        public Task<ApiResult<SalesReceiptPostModel>> CopyAsync(int id, CancellationToken cancellationToken = default)
        {
            var resource = $"{ResourceUrl}/{id}/Copy";
            return GetAsync<SalesReceiptPostModel>(resource, null, cancellationToken);
        }

        /// <inheritdoc/>
        public Task<ApiResult<SalesReceiptPostModel>> DefaultAsync(CancellationToken cancellationToken = default)
        {
            return DefaultAsync<SalesReceiptPostModel>(cancellationToken);
        }

        /// <inheritdoc/>
        public Task<ApiResult<bool>> DeleteAsync(int id, CancellationToken cancellationToken = default)
        {
            return DeleteAsync<bool>(id, cancellationToken);
        }

        /// <inheritdoc/>
        public Task<ApiResult<SalesReceiptGetModel>> PostAsync(SalesReceiptPostModel model, CancellationToken cancellationToken = default)
        {
            return PostAsync<SalesReceiptPostModel, SalesReceiptGetModel>(model, cancellationToken);
        }

        /// <inheritdoc/>
        public Task<ApiBatchResult<SalesReceiptGetModel>> PostAsync(List<SalesReceiptPostModel> models, CancellationToken cancellationToken = default)
        {
            return PostAsync<SalesReceiptPostModel, SalesReceiptGetModel>(models, cancellationToken);
        }

        /// <inheritdoc />
        public Task<ApiResult<SalesReceiptRecountGetModel>> RecountAsync(SalesReceiptRecountPostModel model, CancellationToken cancellationToken = default)
        {
            var resource = $"{ResourceUrl}/Recount";
            return PostAsync<SalesReceiptRecountPostModel, SalesReceiptRecountGetModel>(resource, model, cancellationToken);
        }

        /// <inheritdoc />
        public Task<ApiResult<SalesReceiptGetModel>> UpdateAsync(SalesReceiptPatchModel model, CancellationToken cancellationToken = default)
        {
            return PatchAsync<SalesReceiptPatchModel, SalesReceiptGetModel>(model, cancellationToken);
        }
    }
}
