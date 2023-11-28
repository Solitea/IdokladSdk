using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using IdokladSdk.Clients.Interfaces;
using IdokladSdk.Enums;
using IdokladSdk.Models.CashVoucher;
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
        IPostRequest<CashVoucherPostModel, CashVoucherGetModel>
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
        /// <param name="movementType">Movement type.</param>
        /// <param name="invoiceType">Invoice type.</param>
        /// <param name="invoiceId">Id of invoice.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns><see cref="ApiResult{TData}"/> instance containing <see cref="CashVoucherDefaultGetModel"/>.</returns>
        public async Task<ApiResult<CashVoucherDefaultGetModel>> DefaultAsync(MovementType movementType, InvoiceType invoiceType, int invoiceId, CancellationToken cancellationToken = default)
        {
            var resource = $"{ResourceUrl}/Default/{movementType}/{invoiceType}/{invoiceId}";
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
        /// <param name="cashVoucherId">Id of cash voucher.</param>
        /// <param name="invoiceType">Invoice type.</param>
        /// <param name="invoiceId">Id of invoice.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns><see cref="ApiResult{TData}"/> instance containing <c>true</c> if pairing was successful, otherwise <c>false</c>.</returns>
        public async Task<ApiResult<bool>> PairAsync(int cashVoucherId, InvoiceType invoiceType, int invoiceId, CancellationToken cancellationToken = default)
        {
            var resource = $"{ResourceUrl}/Pair/{cashVoucherId}/{invoiceType}/{invoiceId}";
            var request = await CreateRequestAsync(resource, HttpMethod.Post, cancellationToken).ConfigureAwait(false);

            return await ExecuteAsync<bool>(request, cancellationToken).ConfigureAwait(false);
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
    }
}
