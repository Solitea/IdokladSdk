using System.Threading;
using System.Threading.Tasks;
using IdokladSdk.Models.ReceivedInvoice;
using IdokladSdk.Response;

namespace IdokladSdk.Clients
{
    public partial class ReceivedInvoiceClient
    {
        /// <inheritdoc />
        public Task<ApiResult<ReceivedInvoicePostModel>> CopyAsync(int id, CancellationToken cancellationToken = default)
        {
            var resource = $"{ResourceUrl}/{id}/Copy";
            return GetAsync<ReceivedInvoicePostModel>(resource, null, cancellationToken);
        }

        /// <inheritdoc />
        public Task<ApiResult<ReceivedInvoicePostModel>> DefaultAsync(CancellationToken cancellationToken = default)
        {
            return DefaultAsync<ReceivedInvoicePostModel>(cancellationToken);
        }

        /// <inheritdoc />
        public Task<ApiResult<bool>> DeleteAsync(int id, CancellationToken cancellationToken = default)
        {
            return DeleteAsync<bool>(id, cancellationToken);
        }

        /// <inheritdoc />
        public Task<ApiResult<ReceivedInvoiceGetModel>> PostAsync(ReceivedInvoicePostModel model, CancellationToken cancellationToken = default)
        {
            return PostAsync<ReceivedInvoicePostModel, ReceivedInvoiceGetModel>(model, cancellationToken);
        }

        /// <inheritdoc/>
        public Task<ApiResult<ReceivedInvoiceRecountGetModel>> RecountAsync(ReceivedInvoiceRecountPostModel model, CancellationToken cancellationToken = default)
        {
            var resource = $"{ResourceUrl}/Recount";
            return PostAsync<ReceivedInvoiceRecountPostModel, ReceivedInvoiceRecountGetModel>(resource, model, cancellationToken);
        }

        /// <inheritdoc />
        public Task<ApiResult<ReceivedInvoiceGetModel>> UpdateAsync(ReceivedInvoicePatchModel model, CancellationToken cancellationToken = default)
        {
            return PatchAsync<ReceivedInvoicePatchModel, ReceivedInvoiceGetModel>(model, cancellationToken);
        }
    }
}
