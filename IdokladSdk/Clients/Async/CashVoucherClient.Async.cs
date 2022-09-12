using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using IdokladSdk.Enums;
using IdokladSdk.Models.CashVoucher;
using IdokladSdk.Response;
using RestSharp;

namespace IdokladSdk.Clients
{
    public partial class CashVoucherClient
    {
        /// <summary>
        /// Returns new entity with default property values suitable for subsequent editing and storing.
        /// </summary>
        /// <param name="movementType">Movement type.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns><see cref="ApiResult{TData}"/> instance containing <see cref="CashVoucherPostModel"/>.</returns>
        public async Task<ApiResult<CashVoucherPostModel>> DefaultAsync(MovementType movementType, CancellationToken cancellationToken = default)
        {
            var resource = $"{ResourceUrl}/Default/{movementType}";
            var request = await CreateRequestAsync(resource, HttpMethod.Get, cancellationToken);

            return await ExecuteAsync<CashVoucherPostModel>(request, cancellationToken);
        }

        /// <summary>
        /// Returns new entity with default property values suitable for subsequent editing and storing.
        /// </summary>
        /// <param name="movementType">Movement type.</param>
        /// <param name="invoiceType">Invoice type.</param>
        /// <param name="invoiceId">Id of invoice.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns><see cref="ApiResult{TData}"/> instance containing <see cref="CashVoucherPostModel"/>.</returns>
        public async Task<ApiResult<CashVoucherPostModel>> DefaultAsync(MovementType movementType, InvoiceType invoiceType, int invoiceId, CancellationToken cancellationToken = default)
        {
            var resource = $"{ResourceUrl}/Default/{movementType}/{invoiceType}/{invoiceId}";
            var request = await CreateRequestAsync(resource, HttpMethod.Get, cancellationToken);

            return await ExecuteAsync<CashVoucherPostModel>(request, cancellationToken);
        }

        /// <inheritdoc/>
        public Task<ApiResult<bool>> DeleteAsync(int id, CancellationToken cancellationToken = default)
        {
            return DeleteAsync<bool>(id, cancellationToken);
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
            var request = await CreateRequestAsync(resource, HttpMethod.Post, cancellationToken);

            return await ExecuteAsync<bool>(request, cancellationToken);
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
