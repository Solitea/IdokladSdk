using IdokladSdk.Clients.Interfaces;
using IdokladSdk.Models.IssuedInvoice;
using IdokladSdk.Models.ProformaInvoice;
using IdokladSdk.Models.RecurringInvoice;
using IdokladSdk.Requests.ProformaInvoice;
using IdokladSdk.Response;
using RestSharp;

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
        public ApiResult<ProformaInvoiceCopyGetModel> Copy(int id)
        {
            var resource = $"{ResourceUrl}/{id}/Copy";
            return Get<ProformaInvoiceCopyGetModel>(resource);
        }

        /// <inheritdoc />
        public ApiResult<ProformaInvoicePostModel> Default()
        {
            return Default<ProformaInvoicePostModel>();
        }

        /// <inheritdoc />
        public ApiResult<bool> Delete(int id)
        {
            return Delete<bool>(id);
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
        public ApiResult<ProformaInvoiceGetModel> Post(ProformaInvoicePostModel model)
        {
            return Post<ProformaInvoicePostModel, ProformaInvoiceGetModel>(model);
        }

        /// <inheritdoc />
        public ApiResult<ProformaInvoiceRecountGetModel> Recount(ProformaInvoiceRecountPostModel model)
        {
            var resource = $"{ResourceUrl}/Recount";
            return Post<ProformaInvoiceRecountPostModel, ProformaInvoiceRecountGetModel>(resource, model);
        }

        /// <inheritdoc />
        public ApiResult<RecurringInvoicePostModel> Recurrence(int id)
        {
            var resource = $"{ResourceUrl}/{id}/Recurrence";
            return Get<RecurringInvoicePostModel>(resource);
        }

        /// <inheritdoc />
        public ApiResult<ProformaInvoiceGetModel> Update(ProformaInvoicePatchModel model)
        {
            return Patch<ProformaInvoicePatchModel, ProformaInvoiceGetModel>(model);
        }

        /// <summary>
        /// Returns new issued invoice for accounting of proforma invoice with given id. The proforma invoice must be fully paid.
        /// </summary>
        /// <param name="id">Proforma invoice id.</param>
        /// <returns>Method return issued invoice post model for account proforma invoice.</returns>
        public ApiResult<IssuedInvoicePostModel> GetInvoiceForAccount(int id)
        {
            var resource = $"{ResourceUrl}/{id}/Account";
            return Get<IssuedInvoicePostModel>(resource);
        }

        /// <summary>
        /// Accounts the proforma invoice with given id. The invoice must be fully paid.
        /// </summary>
        /// <param name="id">Proforma invoice id.</param>
        /// <returns>Method account proforma invoice and return created issued invoice model.</returns>
        public ApiResult<IssuedInvoiceGetModel> Account(int id)
        {
            var resource = $"{ResourceUrl}/{id}/Account";
            var request = CreateRequest(resource, Method.PUT);
            return Execute<IssuedInvoiceGetModel>(request);
        }

        /// <summary>
        /// Accounts proforma invoices with ids given in the model.
        /// </summary>
        /// <param name="model">Model containing proforma invoices id.</param>
        /// <returns>Get model of accounting invoice.</returns>
        public ApiResult<IssuedInvoiceGetModel> AccountMultipleProformaInvoices(AccountProformaInvoicesPutModel model)
        {
            var resource = $"{ResourceUrl}/Account";
            return Put<AccountProformaInvoicesPutModel, IssuedInvoiceGetModel>(resource, model);
        }
    }
}
