using System;
using System.Threading;
using System.Threading.Tasks;
using IdokladSdk.Models.ReceivedDocumentPayments;
using IdokladSdk.Response;

namespace IdokladSdk.Clients
{
    public partial class ReceivedDocumentPaymentsClient
    {
        /// <inheritdoc/>
        public Task<ApiResult<ReceivedDocumentPaymentPostModel>> DefaultAsync(int id, CancellationToken cancellationToken = default)
        {
            return DefaultAsync<ReceivedDocumentPaymentPostModel>(id, cancellationToken);
        }

        /// <inheritdoc/>
        public Task<ApiResult<bool>> DeleteAsync(int id, CancellationToken cancellationToken = default)
        {
            return DeleteAsync<bool>(id, cancellationToken);
        }

        /// <inheritdoc/>
        public Task<ApiResult<bool>> FullyUnpayAsync(int invoiceId, CancellationToken cancellationToken = default)
        {
            var resourceUrl = $"{ResourceUrl}/FullyUnpay/{invoiceId}";
            return PutAsync<bool>(resourceUrl, null, cancellationToken);
        }

        /// <summary>
        /// Fully pays document.
        /// </summary>
        /// <param name="invoiceId">Id of invoice.</param>
        /// <param name="dateOfPayment">Date of payment.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns><see cref="ApiResult{TData}"/> instance containing <c>true</c> if full pay was successful, otherwise <c>false</c>.</returns>
        public Task<ApiResult<bool>> FullyPayAsync(int invoiceId, DateTime? dateOfPayment = null, CancellationToken cancellationToken = default)
        {
            var queryParams = GetQueryParamsForFullyPay(dateOfPayment);
            var resourceUrl = $"{ResourceUrl}/FullyPay/{invoiceId}";
            return PutAsync<bool>(resourceUrl, queryParams, cancellationToken);
        }

        /// <inheritdoc/>
        public Task<ApiResult<ReceivedDocumentPaymentGetModel>> PostAsync(ReceivedDocumentPaymentPostModel model, CancellationToken cancellationToken = default)
        {
            return PostAsync<ReceivedDocumentPaymentPostModel, ReceivedDocumentPaymentGetModel>(model, cancellationToken);
        }
    }
}
