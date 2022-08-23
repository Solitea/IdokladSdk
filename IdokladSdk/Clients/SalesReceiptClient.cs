using System;
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
        ICopyRequest<SalesReceiptPostModel>,
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
        [Obsolete("Use async method instead.")]
        public ApiResult<SalesReceiptPostModel> Default()
        {
            return DefaultAsync().GetAwaiter().GetResult();
        }

        /// <inheritdoc/>
        [Obsolete("Use async method instead.")]
        public ApiResult<bool> Delete(int id)
        {
            return DeleteAsync(id).GetAwaiter().GetResult();
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

        /// <inheritdoc />
        [Obsolete("Use async method instead.")]
        public ApiResult<SalesReceiptPostModel> Copy(int id)
        {
            return CopyAsync(id).GetAwaiter().GetResult();
        }

        /// <inheritdoc/>
        [Obsolete("Use async method instead.")]
        public ApiResult<SalesReceiptGetModel> Post(SalesReceiptPostModel model)
        {
            return PostAsync(model).GetAwaiter().GetResult();
        }

        /// <inheritdoc />
        [Obsolete("Use async method instead.")]
        public ApiBatchResult<SalesReceiptGetModel> Post(List<SalesReceiptPostModel> models)
        {
            return PostAsync(models).GetAwaiter().GetResult();
        }

        /// <inheritdoc />
        [Obsolete("Use async method instead.")]
        public ApiResult<SalesReceiptRecountGetModel> Recount(SalesReceiptRecountPostModel model)
        {
            return RecountAsync(model).GetAwaiter().GetResult();
        }

        /// <inheritdoc />
        [Obsolete("Use async method instead.")]
        public ApiResult<SalesReceiptGetModel> Update(SalesReceiptPatchModel model)
        {
            return UpdateAsync(model).GetAwaiter().GetResult();
        }
    }
}
