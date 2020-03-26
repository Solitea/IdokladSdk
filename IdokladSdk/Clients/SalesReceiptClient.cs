using System.Collections.Generic;
using IdokladSdk.Clients.Interfaces;
using IdokladSdk.Models.SalesReceipt;
using IdokladSdk.Requests.SalesReceipt;
using IdokladSdk.Response;

namespace IdokladSdk.Clients
{
    /// <summary>
    /// Client for communication with sales receipt endpoints.
    /// </summary>
    public partial class SalesReceiptClient
        : BaseClient,
        IDeleteRequest,
        IEntityDetail<SalesReceiptDetail>,
        IEntityList<SalesReceiptList>,
        IDefaultRequest<SalesReceiptPostModel>,
        IPatchRequest<SalesReceiptPatchModel, SalesReceiptGetModel>,
        IPostRequest<SalesReceiptPostModel, SalesReceiptGetModel>,
        IPostBatchRequest<SalesReceiptPostModel, SalesReceiptGetModel>,
        IRecountRequest<SalesReceiptRecountPostModel, SalesReceiptRecountGetModel>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SalesReceiptClient"/> class.
        /// </summary>
        /// <param name="apiContext">API context.</param>
        public SalesReceiptClient(ApiContext apiContext)
            : base(apiContext)
        {
        }

        /// <inheritdoc/>
        public override string ResourceUrl { get; } = "/SalesReceipts";

        /// <inheritdoc/>
        public ApiResult<SalesReceiptPostModel> Default()
        {
            return Default<SalesReceiptPostModel>();
        }

        /// <inheritdoc/>
        public ApiResult<bool> Delete(int id)
        {
            return Delete<bool>(id);
        }

        /// <inheritdoc/>
        public SalesReceiptDetail Detail(int id)
        {
            return new SalesReceiptDetail(id, this);
        }

        /// <inheritdoc/>
        public SalesReceiptList List()
        {
            return new SalesReceiptList(this);
        }

        /// <inheritdoc/>
        public ApiResult<SalesReceiptGetModel> Post(SalesReceiptPostModel model)
        {
            return Post<SalesReceiptPostModel, SalesReceiptGetModel>(model);
        }

        /// <inheritdoc />
        public ApiBatchResult<SalesReceiptGetModel> Post(List<SalesReceiptPostModel> models)
        {
            return Post<SalesReceiptPostModel, SalesReceiptGetModel>(models);
        }

        /// <inheritdoc />
        public ApiResult<SalesReceiptRecountGetModel> Recount(SalesReceiptRecountPostModel model)
        {
            var resource = $"{ResourceUrl}/Recount";
            return Post<SalesReceiptRecountPostModel, SalesReceiptRecountGetModel>(resource, model);
        }

        /// <inheritdoc />
        public ApiResult<SalesReceiptGetModel> Update(SalesReceiptPatchModel model)
        {
            return Patch<SalesReceiptPatchModel, SalesReceiptGetModel>(model);
        }
    }
}
