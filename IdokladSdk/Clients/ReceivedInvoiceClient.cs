using System;
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
        [Obsolete("Use async method instead.")]
        public ApiResult<ReceivedInvoicePostModel> Copy(int id)
        {
            return CopyAsync(id).GetAwaiter().GetResult();
        }

        /// <inheritdoc />
        [Obsolete("Use async method instead.")]
        public ApiResult<ReceivedInvoicePostModel> Default()
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
        [Obsolete("Use async method instead.")]
        public ApiResult<ReceivedInvoiceGetModel> Post(ReceivedInvoicePostModel model)
        {
            return PostAsync(model).GetAwaiter().GetResult();
        }

        /// <inheritdoc/>
        [Obsolete("Use async method instead.")]
        public ApiResult<ReceivedInvoiceRecountGetModel> Recount(ReceivedInvoiceRecountPostModel model)
        {
            return RecountAsync(model).GetAwaiter().GetResult();
        }

        /// <inheritdoc />
        [Obsolete("Use async method instead.")]
        public ApiResult<ReceivedInvoiceGetModel> Update(ReceivedInvoicePatchModel model)
        {
            return UpdateAsync(model).GetAwaiter().GetResult();
        }
    }
}
