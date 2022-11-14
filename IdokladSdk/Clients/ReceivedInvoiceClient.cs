using System.Threading;
using System.Threading.Tasks;
using IdokladSdk.Clients.Interfaces;
using IdokladSdk.Models.ReceivedInvoice;
using IdokladSdk.Requests.ReceivedInvoice;
using IdokladSdk.Response;

namespace IdokladSdk.Clients
{
    /// <summary>
    /// Client for communication with received invoice endpoints.
    /// </summary>
    public class ReceivedInvoiceClient :
        BaseClient,
        ICopyRequest<ReceivedInvoicePostModel>,
        IDeleteRequest,
        IEntityList<ReceivedInvoiceList>,
        IEntityDetail<ReceivedInvoiceDetail>,
        IDefaultRequest<ReceivedInvoicePostModel>,
        IPostRequest<ReceivedInvoicePostModel, ReceivedInvoiceGetModel>,
        IPatchRequest<ReceivedInvoicePatchModel, ReceivedInvoiceGetModel>,
        IRecountRequest<ReceivedInvoiceRecountPostModel, ReceivedInvoiceRecountGetModel>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ReceivedInvoiceClient"/> class.
        /// </summary>
        /// <param name="apiContext">Context.</param>
        public ReceivedInvoiceClient(ApiContext apiContext)
            : base(apiContext)
        {
        }

        /// <inheritdoc />
        public override string ResourceUrl { get; } = "/ReceivedInvoices";

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
        public ReceivedInvoiceDetail Detail(int id)
        {
            return new ReceivedInvoiceDetail(id, this);
        }

        /// <inheritdoc />
        public ReceivedInvoiceList List()
        {
            return new ReceivedInvoiceList(this);
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
