using System.Threading;
using System.Threading.Tasks;
using IdokladSdk.Models.RecurringInvoice;
using IdokladSdk.Models.RecurringInvoice.Get;
using IdokladSdk.Response;

namespace IdokladSdk.Clients
{
    public partial class RecurringInvoiceClient
    {
        /// <inheritdoc />
        public Task<ApiResult<RecurringInvoicePostModel>> DefaultAsync(CancellationToken cancellationToken = default)
        {
            return DefaultAsync<RecurringInvoicePostModel>(cancellationToken);
        }

        /// <inheritdoc />
        public Task<ApiResult<bool>> DeleteAsync(int id, CancellationToken cancellationToken = default)
        {
            return DeleteAsync<bool>(id, cancellationToken);
        }

        /// <inheritdoc cref="NextIssueDates"/>
        /// <param name="model">Recurrence setting.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        public Task<ApiResult<NextIssueDatesGetModel>> NextIssueDatesAsync(NextIssueDatesPostModel model, CancellationToken cancellationToken = default)
        {
            var resource = $"{ResourceUrl}/NextIssueDates";
            return PostAsync<NextIssueDatesPostModel, NextIssueDatesGetModel>(resource, model, cancellationToken);
        }

        /// <inheritdoc />
        public Task<ApiResult<RecurringInvoiceResultGetModel>> PostAsync(RecurringInvoicePostModel model, CancellationToken cancellationToken = default)
        {
            return PostAsync<RecurringInvoicePostModel, RecurringInvoiceResultGetModel>(model, cancellationToken);
        }

        /// <inheritdoc />
        public Task<ApiResult<InvoiceTemplateRecountGetModel>> RecountAsync(InvoiceTemplateRecountPostModel model, CancellationToken cancellationToken = default)
        {
            var resource = $"{ResourceUrl}/Recount";
            return PostAsync<InvoiceTemplateRecountPostModel, InvoiceTemplateRecountGetModel>(resource, model, cancellationToken);
        }

        /// <inheritdoc />
        public Task<ApiResult<RecurringInvoiceGetModel>> UpdateAsync(RecurringInvoicePatchModel model, CancellationToken cancellationToken = default)
        {
            return PatchAsync<RecurringInvoicePatchModel, RecurringInvoiceGetModel>(model, cancellationToken);
        }

        /// <inheritdoc cref="Copy"/>
        public Task<ApiResult<RecurringInvoiceCopyGetModel>> CopyAsync(int id, CancellationToken cancellationToken = default)
        {
            var resource = $"{ResourceUrl}/{id}/Copy";
            return GetAsync<RecurringInvoiceCopyGetModel>(resource, null, cancellationToken);
        }
    }
}
