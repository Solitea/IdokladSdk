using IdokladSdk.Clients.Interfaces;
using IdokladSdk.Models.RecurringInvoice;
using IdokladSdk.Requests.RecurringInvoice;
using IdokladSdk.Response;

namespace IdokladSdk.Clients
{
    public partial class RecurringInvoiceClient
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
        public ApiResult<RecurringInvoicePostModel> Default()
        {
            return Default<RecurringInvoicePostModel>();
        }

        /// <inheritdoc />
        public ApiResult<bool> Delete(int id)
        {
            return Delete<bool>(id);
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
        /// <returns>Next issue dates.</returns>
        public ApiResult<NextIssueDatesGetModel> NextIssueDates(NextIssueDatesPostModel model)
        {
            var resource = $"{ResourceUrl}/NextIssueDates";
            return Post<NextIssueDatesPostModel, NextIssueDatesGetModel>(resource, model);
        }

        /// <inheritdoc />
        public ApiResult<RecurringInvoiceResultGetModel> Post(RecurringInvoicePostModel model)
        {
            return Post<RecurringInvoicePostModel, RecurringInvoiceResultGetModel>(model);
        }

        /// <inheritdoc />
        public ApiResult<InvoiceTemplateRecountGetModel> Recount(InvoiceTemplateRecountPostModel model)
        {
            var resource = $"{ResourceUrl}/Recount";
            return Post<InvoiceTemplateRecountPostModel, InvoiceTemplateRecountGetModel>(resource, model);
        }

        /// <inheritdoc />
        public ApiResult<RecurringInvoiceGetModel> Update(RecurringInvoicePatchModel model)
        {
            return Patch<RecurringInvoicePatchModel, RecurringInvoiceGetModel>(model);
        }
    }
}
