using System.Collections.Generic;
using System.Globalization;
using System.Threading;
using System.Threading.Tasks;
using IdokladSdk.Clients.Interfaces;
using IdokladSdk.Models.ReceivedReceipt.Get;
using IdokladSdk.Models.ReceivedReceipt.Patch;
using IdokladSdk.Models.ReceivedReceipt.Post;
using IdokladSdk.Models.ReceivedReceipt.Recount;
using IdokladSdk.Requests.ReceivedReceipt;
using IdokladSdk.Response;

namespace IdokladSdk.Clients
{
    /// <summary>
    /// Client for communication with received receipt endpoints.
    /// </summary>
    public class ReceivedReceiptClient : BaseClient,
        IDefaultRequest<ReceivedReceiptDefaultGetModel>,
        IDeleteRequest,
        IEntityList<ReceivedReceiptList>,
        IEntityDetail<ReceivedReceiptDetail>,
        IPostRequest<ReceivedReceiptPostModel, ReceivedReceiptGetModel>,
        IPatchRequest<ReceivedReceiptPatchModel, ReceivedReceiptGetModel>,
        IRecountRequest<ReceivedReceiptRecountPostModel, ReceivedReceiptRecountGetModel>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ReceivedReceiptClient"/> class.
        /// </summary>
        /// <param name="apiContext">Context.</param>
        public ReceivedReceiptClient(ApiContext apiContext)
            : base(apiContext)
        {
        }

        /// <inheritdoc/>
        public override string ResourceUrl { get; } = "/ReceivedReceipts";

        /// <inheritdoc/>
        public Task<ApiResult<ReceivedReceiptDefaultGetModel>> DefaultAsync(
            CancellationToken cancellationToken = default)
        {
            return DefaultAsync<ReceivedReceiptDefaultGetModel>(cancellationToken);
        }

        /// <summary>
        /// Returns new entity with property values based on inbox record suitable for subsequent editing and storing.
        /// </summary>
        /// <param name="inboxId">Inbox record ID.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns><see cref="ApiResult{ReceivedReceiptDefaultGetModel}"/> instance.</returns>
        public Task<ApiResult<ReceivedReceiptDefaultGetModel>> DefaultAsync(
            int inboxId,
            CancellationToken cancellationToken = default)
        {
            var queryParams = new Dictionary<string, string>() { { "inboxId", inboxId.ToString(CultureInfo.InvariantCulture) } };
            return DefaultAsync<ReceivedReceiptDefaultGetModel>(queryParams, cancellationToken);
        }

        /// <inheritdoc/>
        public Task<ApiResult<bool>> DeleteAsync(int id, CancellationToken cancellationToken = default)
        {
            return DeleteAsync<bool>(id, cancellationToken);
        }

        /// <inheritdoc/>
        public ReceivedReceiptList List()
        {
            return new ReceivedReceiptList(this);
        }

        /// <inheritdoc/>
        public ReceivedReceiptDetail Detail(int id)
        {
            return new ReceivedReceiptDetail(id, this);
        }

        /// <inheritdoc />
        public Task<ApiResult<ReceivedReceiptGetModel>> PostAsync(ReceivedReceiptPostModel model, CancellationToken cancellationToken = default)
        {
            return PostAsync<ReceivedReceiptPostModel, ReceivedReceiptGetModel>(model, cancellationToken);
        }

        /// <inheritdoc/>
        public Task<ApiResult<ReceivedReceiptRecountGetModel>> RecountAsync(ReceivedReceiptRecountPostModel model, CancellationToken cancellationToken = default)
        {
            var resource = $"{ResourceUrl}/Recount";
            return PostAsync<ReceivedReceiptRecountPostModel, ReceivedReceiptRecountGetModel>(resource, model, cancellationToken);
        }

        /// <inheritdoc />
        public Task<ApiResult<ReceivedReceiptGetModel>> UpdateAsync(ReceivedReceiptPatchModel model, CancellationToken cancellationToken = default)
        {
            return PatchAsync<ReceivedReceiptPatchModel, ReceivedReceiptGetModel>(model, cancellationToken);
        }
    }
}
