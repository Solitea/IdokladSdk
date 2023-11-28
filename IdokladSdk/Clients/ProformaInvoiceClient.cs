using System.Collections.Generic;
using System.Globalization;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
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
    public class ProformaInvoiceClient : BaseClient,
        ICopyRequest<ProformaInvoiceCopyGetModel>,
        IDefaultRequest<ProformaInvoiceDefaultGetModel>,
        IDefaultWithIdRequest<ProformaInvoiceDefaultGetModel>,
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
        public Task<ApiResult<ProformaInvoiceCopyGetModel>> CopyAsync(int id, CancellationToken cancellationToken = default)
        {
            var resource = $"{ResourceUrl}/{id}/Copy";
            return GetAsync<ProformaInvoiceCopyGetModel>(resource, null, cancellationToken);
        }

        /// <inheritdoc />
        public Task<ApiResult<ProformaInvoiceDefaultGetModel>> DefaultAsync(CancellationToken cancellationToken = default)
        {
            return DefaultAsync<ProformaInvoiceDefaultGetModel>(cancellationToken);
        }

        /// <inheritdoc />
        public Task<ApiResult<ProformaInvoiceDefaultGetModel>> DefaultAsync(int templateId, CancellationToken cancellationToken = default)
        {
            var queryParams = new Dictionary<string, string>() { { "templateId", templateId.ToString(CultureInfo.InvariantCulture) } };
            return DefaultAsync<ProformaInvoiceDefaultGetModel>(queryParams, cancellationToken);
        }

        /// <inheritdoc />
        public Task<ApiResult<bool>> DeleteAsync(int id, CancellationToken cancellationToken = default)
        {
            return DeleteAsync<bool>(id, cancellationToken);
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
        public Task<ApiResult<ProformaInvoiceGetModel>> PostAsync(ProformaInvoicePostModel model, CancellationToken cancellationToken = default)
        {
            return PostAsync<ProformaInvoicePostModel, ProformaInvoiceGetModel>(model, cancellationToken);
        }

        /// <inheritdoc />
        public Task<ApiResult<ProformaInvoiceRecountGetModel>> RecountAsync(ProformaInvoiceRecountPostModel model, CancellationToken cancellationToken = default)
        {
            var resource = $"{ResourceUrl}/Recount";
            return PostAsync<ProformaInvoiceRecountPostModel, ProformaInvoiceRecountGetModel>(resource, model, cancellationToken);
        }

        /// <inheritdoc />
        public Task<ApiResult<RecurringInvoicePostModel>> RecurrenceAsync(int id, CancellationToken cancellationToken = default)
        {
            var resource = $"{ResourceUrl}/{id}/Recurrence";
            return GetAsync<RecurringInvoicePostModel>(resource, null, cancellationToken);
        }

        /// <inheritdoc />
        public Task<ApiResult<ProformaInvoiceGetModel>> UpdateAsync(ProformaInvoicePatchModel model, CancellationToken cancellationToken = default)
        {
            return PatchAsync<ProformaInvoicePatchModel, ProformaInvoiceGetModel>(model, cancellationToken);
        }

        /// <summary>
        /// Returns new issued invoice for accounting of proforma invoice with given id. The proforma invoice must be fully paid.
        /// </summary>
        /// <param name="id">Proforma invoice id.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns>Method return issued invoice post model for account proforma invoice.</returns>
        public Task<ApiResult<IssuedInvoicePostModel>> GetInvoiceForAccountAsync(int id, CancellationToken cancellationToken = default)
        {
            var resource = $"{ResourceUrl}/{id}/Account";
            return GetAsync<IssuedInvoicePostModel>(resource, null, cancellationToken);
        }

        /// <summary>
        /// Accounts the proforma invoice with given id. The invoice must be fully paid.
        /// </summary>
        /// <param name="id">Proforma invoice id.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns>Method account proforma invoice and return created issued invoice model.</returns>
        public async Task<ApiResult<IssuedInvoiceGetModel>> AccountAsync(int id, CancellationToken cancellationToken = default)
        {
            var resource = $"{ResourceUrl}/{id}/Account";
            var request = await CreateRequestAsync(resource, HttpMethod.Put, cancellationToken).ConfigureAwait(false);
            return await ExecuteAsync<IssuedInvoiceGetModel>(request, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Accounts proforma invoices with ids given in the model.
        /// </summary>
        /// <param name="model">Model containing proforma invoices id.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns>Get model of accounting invoice.</returns>
        public async Task<ApiResult<IssuedInvoiceGetModel>> AccountMultipleProformaInvoicesAsync(
            AccountProformaInvoicesPutModel model, CancellationToken cancellationToken = default)
        {
            var resource = $"{ResourceUrl}/Account";
            return await PutAsync<AccountProformaInvoicesPutModel, IssuedInvoiceGetModel>(resource, model, cancellationToken).ConfigureAwait(false);
        }
    }
}
