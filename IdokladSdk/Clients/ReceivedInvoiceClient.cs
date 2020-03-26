using IdokladSdk.Clients.Interfaces;
using IdokladSdk.Models.ReceivedInvoice;
using IdokladSdk.Requests.ReceivedInvoice;
using IdokladSdk.Response;

namespace IdokladSdk.Clients
{
    /// <summary>
    /// Client for communication with received invoice endpoints.
    /// </summary>
    public partial class ReceivedInvoiceClient :
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
        public ApiResult<ReceivedInvoicePostModel> Copy(int id)
        {
            var resource = $"{ResourceUrl}/{id}/Copy";
            return Get<ReceivedInvoicePostModel>(resource);
        }

        /// <inheritdoc />
        public ApiResult<ReceivedInvoicePostModel> Default()
        {
            return Default<ReceivedInvoicePostModel>();
        }

        /// <inheritdoc />
        public ApiResult<bool> Delete(int id)
        {
            return Delete<bool>(id);
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
        public ApiResult<ReceivedInvoiceGetModel> Post(ReceivedInvoicePostModel model)
        {
            return Post<ReceivedInvoicePostModel, ReceivedInvoiceGetModel>(model);
        }

        /// <inheritdoc/>
        public ApiResult<ReceivedInvoiceRecountGetModel> Recount(ReceivedInvoiceRecountPostModel model)
        {
            var resource = $"{ResourceUrl}/Recount";
            return Post<ReceivedInvoiceRecountPostModel, ReceivedInvoiceRecountGetModel>(resource, model);
        }

        /// <inheritdoc />
        public ApiResult<ReceivedInvoiceGetModel> Update(ReceivedInvoicePatchModel model)
        {
            return Patch<ReceivedInvoicePatchModel, ReceivedInvoiceGetModel>(model);
        }
    }
}
