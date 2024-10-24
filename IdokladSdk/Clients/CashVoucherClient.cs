using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using IdokladSdk.Clients.Interfaces;
using IdokladSdk.Enums;
using IdokladSdk.Models.CashVoucher;
using IdokladSdk.Models.CashVoucher.Pair;
using IdokladSdk.Models.CashVoucher.Recount;
using IdokladSdk.Requests.CashVoucher;
using IdokladSdk.Response;

namespace IdokladSdk.Clients
{
    /// <summary>
    /// Client for communication with cash voucher endpoints.
    /// </summary>
    public class CashVoucherClient :
        BaseClient,
        IDeleteRequest,
        IEntityDetail<CashVoucherDetail>,
        IEntityList<CashVoucherList>,
        IPatchRequest<CashVoucherPatchModel, CashVoucherGetModel>,
        IPostRequest<CashVoucherPostModel, CashVoucherGetModel>,
        IRecountRequest<CashVoucherRecountPostModel, CashVoucherRecountGetModel>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CashVoucherClient"/> class.
        /// </summary>
        /// <param name="context">API context.</param>
        public CashVoucherClient(ApiContext context)
            : base(context)
        {
        }

        /// <inheritdoc/>
        public override string ResourceUrl => "/CashVouchers";

        /// <summary>
        /// Returns new entity with default property values suitable for subsequent editing and storing.
        /// </summary>
        /// <param name="movementType">Movement type.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns><see cref="ApiResult{TData}"/> instance containing <see cref="CashVoucherDefaultGetModel"/>.</returns>
        public async Task<ApiResult<CashVoucherDefaultGetModel>> DefaultAsync(MovementType movementType, CancellationToken cancellationToken = default)
        {
            var resource = $"{ResourceUrl}/Default/{movementType}";
            var request = await CreateRequestAsync(resource, HttpMethod.Get, cancellationToken).ConfigureAwait(false);

            return await ExecuteAsync<CashVoucherDefaultGetModel>(request, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Returns new entity with default property values suitable for subsequent editing and storing.
        /// </summary>
        /// <param name="documentType">Document type.</param>
        /// <param name="documentId">Id of document.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns><see cref="ApiResult{TData}"/> instance containing <see cref="CashVoucherDefaultGetModel"/>.</returns>
        public async Task<ApiResult<CashVoucherDefaultGetModel>> DefaultAsync(PairedDocumentType documentType, int documentId, CancellationToken cancellationToken = default)
        {
            var resource = $"{ResourceUrl}/Default/{documentType}/{documentId}";
            var request = await CreateRequestAsync(resource, HttpMethod.Get, cancellationToken).ConfigureAwait(false);

            return await ExecuteAsync<CashVoucherDefaultGetModel>(request, cancellationToken).ConfigureAwait(false);
        }

        /// <inheritdoc/>
        public Task<ApiResult<bool>> DeleteAsync(int id, CancellationToken cancellationToken = default)
        {
            return DeleteAsync<bool>(id, cancellationToken);
        }

        /// <inheritdoc/>
        public CashVoucherDetail Detail(int id)
        {
            return new CashVoucherDetail(id, this);
        }

        /// <inheritdoc/>
        public CashVoucherList List()
        {
            return new CashVoucherList(this);
        }

        /// <summary>
        /// Pairs cash voucher with unpaid invoice.
        /// </summary>
        /// <param name="model">Model.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns><see cref="ApiResult{TData}"/> instance containing <c>true</c> if pairing was successful, otherwise <c>false</c>.</returns>
        public Task<ApiResult<bool>> PairWithDocumentAsync(CashVoucherPairPostModel model, CancellationToken cancellationToken = default)
        {
            var resource = $"{ResourceUrl}/PairWithDocument";
            return PostAsync<CashVoucherPairPostModel, bool>(resource, model, cancellationToken);
        }

        /// <inheritdoc/>
        public Task<ApiResult<CashVoucherGetModel>> PostAsync(CashVoucherPostModel model, CancellationToken cancellationToken = default)
        {
            return PostAsync<CashVoucherPostModel, CashVoucherGetModel>(model, cancellationToken);
        }

        /// <inheritdoc/>
        public Task<ApiResult<CashVoucherGetModel>> UpdateAsync(CashVoucherPatchModel model, CancellationToken cancellationToken = default)
        {
            return PatchAsync<CashVoucherPatchModel, CashVoucherGetModel>(model, cancellationToken);
        }

        /// <inheritdoc/>
        public Task<ApiResult<CashVoucherRecountGetModel>> RecountAsync(CashVoucherRecountPostModel model, CancellationToken cancellationToken = default)
        {
            var resource = $"{ResourceUrl}/Recount";
            return PostAsync<CashVoucherRecountPostModel, CashVoucherRecountGetModel>(resource, model, cancellationToken);
        }
    }
}
