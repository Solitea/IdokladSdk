using System;
using IdokladSdk.Clients.Interfaces;
using IdokladSdk.Models.RecurringInvoice;
using IdokladSdk.Models.RecurringInvoice.Get;
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
        [Obsolete("Use async method instead.")]
        public ApiResult<RecurringInvoicePostModel> Default()
        {
            return DefaultAsync().GetAwaiter().GetResult();
        }

        /// <inheritdoc />
        [Obsolete("Use async method instead.")]
        public ApiResult<bool> Delete(int id)
        {
            return DeleteAsync(id).GetAwaiter().GetResult();
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
        [Obsolete("Use async method instead.")]
        public ApiResult<NextIssueDatesGetModel> NextIssueDates(NextIssueDatesPostModel model)
        {
            return NextIssueDatesAsync(model).GetAwaiter().GetResult();
        }

        /// <inheritdoc />
        [Obsolete("Use async method instead.")]
        public ApiResult<RecurringInvoiceResultGetModel> Post(RecurringInvoicePostModel model)
        {
            return PostAsync(model).GetAwaiter().GetResult();
        }

        /// <inheritdoc />
        [Obsolete("Use async method instead.")]
        public ApiResult<InvoiceTemplateRecountGetModel> Recount(InvoiceTemplateRecountPostModel model)
        {
            return RecountAsync(model).GetAwaiter().GetResult();
        }

        /// <inheritdoc />
        [Obsolete("Use async method instead.")]
        public ApiResult<RecurringInvoiceGetModel> Update(RecurringInvoicePatchModel model)
        {
            return UpdateAsync(model).GetAwaiter().GetResult();
        }

        /// <summary>
        /// Method returns copy of recurring invoice. Returned resource is suitable for new invoice creation.
        /// </summary>
        /// <param name="id">Invoice id.</param>
        /// <returns>Resource of recurring invoice for creation.</returns>
        [Obsolete("Use async method instead.")]
        public ApiResult<RecurringInvoiceCopyGetModel> Copy(int id)
        {
            return CopyAsync(id).GetAwaiter().GetResult();
        }
    }
}
