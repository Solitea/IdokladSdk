using System.Threading;
using System.Threading.Tasks;
using IdokladSdk.Clients.Interfaces;
using IdokladSdk.Models.RecurringInvoice;
using IdokladSdk.Models.RecurringInvoice.Get;
using IdokladSdk.Requests.RecurringInvoice;
using IdokladSdk.Response;

namespace IdokladSdk.Clients
{
    /// <summary>
    /// Client for communication with recurring invoice endpoints.
    /// </summary>
    public class RecurringInvoiceClient
        : BaseClient,
        IDeleteRequest,
        IEntityDetail<RecurringInvoiceDetail>,
        IEntityList<RecurringInvoiceList>,
        IDefaultRequest<RecurringInvoicePostModel>,
        IPostRequest<RecurringInvoicePostModel, RecurringInvoiceResultGetModel>,
        IPatchRequest<RecurringInvoicePatchModel, RecurringInvoiceGetModel>,
        IRecountRequest<InvoiceTemplateRecountPostModel, InvoiceTemplateRecountGetModel>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="RecurringInvoiceClient"/> class.
        /// </summary>
        /// <param name="apiContext">API context.</param>
        public RecurringInvoiceClient(ApiContext apiContext)
            : base(apiContext)
        {
        }

        /// <inheritdoc />
        public override string ResourceUrl { get; } = "/RecurringInvoices";

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

        /// <inheritdoc />
        public RecurringInvoiceDetail Detail(int id)
        {
            return new RecurringInvoiceDetail(id, this);
        }

        /// <inheritdoc />
        public RecurringInvoiceList List()
        {
            return new RecurringInvoiceList(this);
        }

        /// <summary>
        /// Method returns list of next issue dates (max 12 future dates) for recurring invoice setting. List of dates is based on recurrence setting input.
        /// </summary>
        /// <param name="model">Recurrence setting.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns>Next issue dates.</returns>
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

        /// <summary>
        /// Method returns copy of recurring invoice. Returned resource is suitable for new invoice creation.
        /// </summary>
        /// <param name="id">Invoice id.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns>Resource of recurring invoice for creation.</returns>
        public Task<ApiResult<RecurringInvoiceCopyGetModel>> CopyAsync(int id, CancellationToken cancellationToken = default)
        {
            var resource = $"{ResourceUrl}/{id}/Copy";
            return GetAsync<RecurringInvoiceCopyGetModel>(resource, null, cancellationToken);
        }
    }
}
