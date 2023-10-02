using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using IdokladSdk.Clients.Interfaces;
using IdokladSdk.Models.SalesReceipt;
using IdokladSdk.Models.SalesReceipt.Copy;
using IdokladSdk.Requests.SalesReceipt;
using IdokladSdk.Response;

namespace IdokladSdk.Clients
{
    /// <summary>
    /// Client for communication with sales receipt endpoints.
    /// </summary>
    public class SalesReceiptClient
        : BaseClient,
        ICopyRequest<SalesReceiptCopyGetModel>,
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
        public Task<ApiResult<SalesReceiptPostModel>> DefaultAsync(CancellationToken cancellationToken = default)
        {
            return DefaultAsync<SalesReceiptPostModel>(cancellationToken);
        }

        /// <inheritdoc/>
        public Task<ApiResult<bool>> DeleteAsync(int id, CancellationToken cancellationToken = default)
        {
            return DeleteAsync<bool>(id, cancellationToken);
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
        public Task<ApiResult<SalesReceiptCopyGetModel>> CopyAsync(int id, CancellationToken cancellationToken = default)
        {
            var resource = $"{ResourceUrl}/{id}/Copy";
            return GetAsync<SalesReceiptCopyGetModel>(resource, null, cancellationToken);
        }

        /// <inheritdoc/>
        public Task<ApiResult<SalesReceiptGetModel>> PostAsync(SalesReceiptPostModel model, CancellationToken cancellationToken = default)
        {
            return PostAsync<SalesReceiptPostModel, SalesReceiptGetModel>(model, cancellationToken);
        }

        /// <inheritdoc />
        public Task<ApiBatchResult<SalesReceiptGetModel>> PostAsync(List<SalesReceiptPostModel> models, CancellationToken cancellationToken = default)
        {
            return PostAsync<SalesReceiptPostModel, SalesReceiptGetModel>(models, cancellationToken);
        }

        /// <inheritdoc />
        public Task<ApiResult<SalesReceiptRecountGetModel>> RecountAsync(SalesReceiptRecountPostModel model, CancellationToken cancellationToken = default)
        {
            var resource = $"{ResourceUrl}/Recount";
            return PostAsync<SalesReceiptRecountPostModel, SalesReceiptRecountGetModel>(resource, model, cancellationToken);
        }

        /// <inheritdoc />
        public Task<ApiResult<SalesReceiptGetModel>> UpdateAsync(SalesReceiptPatchModel model, CancellationToken cancellationToken = default)
        {
            return PatchAsync<SalesReceiptPatchModel, SalesReceiptGetModel>(model, cancellationToken);
        }
    }
}
