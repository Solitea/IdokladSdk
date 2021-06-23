using System.Threading;
using System.Threading.Tasks;
using IdokladSdk.Models.IssuedInvoice;
using IdokladSdk.Models.RecurringInvoice.Get;
using IdokladSdk.Response;

namespace IdokladSdk.Clients
{
    public partial class IssuedInvoiceClient
    {
        /// <inheritdoc/>
        public Task<ApiResult<IssuedInvoiceCopyGetModel>> CopyAsync(int id, CancellationToken cancellationToken = default)
        {
            var resource = $"{ResourceUrl}/{id}/Copy";
            return GetAsync<IssuedInvoiceCopyGetModel>(resource, null, cancellationToken);
        }

        /// <inheritdoc />
        public Task<ApiResult<IssuedInvoicePostModel>> DefaultAsync(CancellationToken cancellationToken = default)
        {
            return DefaultAsync<IssuedInvoicePostModel>(cancellationToken);
        }

        /// <inheritdoc />
        public Task<ApiResult<bool>> DeleteAsync(int id, CancellationToken cancellationToken = default)
        {
            return DeleteAsync<bool>(id, cancellationToken);
        }

        /// <inheritdoc />
        public Task<ApiResult<IssuedInvoiceGetModel>> PostAsync(IssuedInvoicePostModel model, CancellationToken cancellationToken = default)
        {
            ValidatePost(model);
            return PostAsync<IssuedInvoicePostModel, IssuedInvoiceGetModel>(model, cancellationToken);
        }

        /// <inheritdoc />
        public Task<ApiResult<IssuedInvoiceRecountGetModel>> RecountAsync(IssuedInvoiceRecountPostModel model, CancellationToken cancellationToken = default)
        {
            var resource = $"{ResourceUrl}/Recount";
            return PostAsync<IssuedInvoiceRecountPostModel, IssuedInvoiceRecountGetModel>(resource, model, cancellationToken);
        }

        /// <inheritdoc />
        public Task<ApiResult<RecurringInvoiceFromInvoiceGetModel>> RecurrenceAsync(int id, CancellationToken cancellationToken = default)
        {
            var resource = $"{ResourceUrl}/{id}/Recurrence";
            return GetAsync<RecurringInvoiceFromInvoiceGetModel>(resource, null, cancellationToken);
        }

        /// <inheritdoc />
        public Task<ApiResult<IssuedInvoiceGetModel>> UpdateAsync(IssuedInvoicePatchModel model, CancellationToken cancellationToken = default)
        {
            return PatchAsync<IssuedInvoicePatchModel, IssuedInvoiceGetModel>(model, cancellationToken);
        }
    }
}
