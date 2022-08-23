using System;
using IdokladSdk.Clients.Interfaces;
using IdokladSdk.Models.IssuedInvoice;
using IdokladSdk.Models.ProformaInvoice;
using IdokladSdk.Models.RecurringInvoice;
using IdokladSdk.Requests.ProformaInvoice;
using IdokladSdk.Response;

namespace IdokladSdk.Clients
{
    /// <summary>
    /// Client for communication with proforma invoice endpoints.
    /// </summary>
    public partial class ProformaInvoiceClient : BaseClient,
        ICopyRequest<ProformaInvoiceCopyGetModel>,
        IDefaultRequest<ProformaInvoicePostModel>,
        IDeleteRequest,
        IEntityDetail<ProformaInvoiceDetail>,
        IEntityList<ProformaInvoiceList>,
        IPatchRequest<ProformaInvoicePatchModel, ProformaInvoiceGetModel>,
        IPostRequest<ProformaInvoicePostModel, ProformaInvoiceGetModel>,
        IRecountRequest<ProformaInvoiceRecountPostModel, ProformaInvoiceRecountGetModel>,
        IRecurrenceRequest<RecurringInvoicePostModel>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ProformaInvoiceClient"/> class.
        /// </summary>
        /// <param name="apiContext">Context.</param>
        public ProformaInvoiceClient(ApiContext apiContext)
            : base(apiContext)
        {
        }

        /// <inheritdoc />
        public override string ResourceUrl { get; } = "/ProformaInvoices";

        /// <inheritdoc />
        [Obsolete("Use async method instead.")]
        public ApiResult<ProformaInvoiceCopyGetModel> Copy(int id)
        {
            return CopyAsync(id).GetAwaiter().GetResult();
        }

        /// <inheritdoc />
        [Obsolete("Use async method instead.")]
        public ApiResult<ProformaInvoicePostModel> Default()
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
        public ProformaInvoiceDetail Detail(int id)
        {
            return new ProformaInvoiceDetail(id, this);
        }

        /// <inheritdoc />
        public ProformaInvoiceList List()
        {
            return new ProformaInvoiceList(this);
        }

        /// <inheritdoc />
        [Obsolete("Use async method instead.")]
        public ApiResult<ProformaInvoiceGetModel> Post(ProformaInvoicePostModel model)
        {
            return PostAsync(model).GetAwaiter().GetResult();
        }

        /// <inheritdoc />
        public ApiResult<ProformaInvoiceRecountGetModel> Recount(ProformaInvoiceRecountPostModel model)
        {
            return RecountAsync(model).GetAwaiter().GetResult();
        }

        /// <inheritdoc />
        [Obsolete("Use async method instead.")]
        public ApiResult<RecurringInvoicePostModel> Recurrence(int id)
        {
            return RecurrenceAsync(id).GetAwaiter().GetResult();
        }

        /// <inheritdoc />
        [Obsolete("Use async method instead.")]
        public ApiResult<ProformaInvoiceGetModel> Update(ProformaInvoicePatchModel model)
        {
            return UpdateAsync(model).GetAwaiter().GetResult();
        }

        /// <summary>
        /// Returns new issued invoice for accounting of proforma invoice with given id. The proforma invoice must be fully paid.
        /// </summary>
        /// <param name="id">Proforma invoice id.</param>
        /// <returns>Method return issued invoice post model for account proforma invoice.</returns>
        [Obsolete("Use async method instead.")]
        public ApiResult<IssuedInvoicePostModel> GetInvoiceForAccount(int id)
        {
            return GetInvoiceForAccountAsync(id).GetAwaiter().GetResult();
        }

        /// <summary>
        /// Accounts the proforma invoice with given id. The invoice must be fully paid.
        /// </summary>
        /// <param name="id">Proforma invoice id.</param>
        /// <returns>Method account proforma invoice and return created issued invoice model.</returns>
        [Obsolete("Use async method instead.")]
        public ApiResult<IssuedInvoiceGetModel> Account(int id)
        {
            return AccountAsync(id).GetAwaiter().GetResult();
        }

        /// <summary>
        /// Accounts proforma invoices with ids given in the model.
        /// </summary>
        /// <param name="model">Model containing proforma invoices id.</param>
        /// <returns>Get model of accounting invoice.</returns>
        [Obsolete("Use async method instead.")]
        public ApiResult<IssuedInvoiceGetModel> AccountMultipleProformaInvoices(AccountProformaInvoicesPutModel model)
        {
            return AccountMultipleProformaInvoicesAsync(model).GetAwaiter().GetResult();
        }
    }
}
