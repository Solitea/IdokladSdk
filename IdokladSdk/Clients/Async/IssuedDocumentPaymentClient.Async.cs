using System;
using System.Threading;
using System.Threading.Tasks;
using IdokladSdk.Models.IssuedDocumentPayment;
using IdokladSdk.Response;

namespace IdokladSdk.Clients
{
    public partial class IssuedDocumentPaymentClient
    {
        /// <inheritdoc/>
        public Task<ApiResult<IssuedDocumentPaymentPostModel>> DefaultAsync(int id, CancellationToken cancellationToken = default)
        {
            return DefaultAsync<IssuedDocumentPaymentPostModel>(id, cancellationToken);
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

        /// <inheritdoc cref="FullyPay"/>
        public Task<ApiResult<bool>> FullyPayAsync(int invoiceId, DateTime? dateOfPayment = null, int? salesPosEquipmentId = null, CancellationToken cancellationToken = default)
        {
            var queryParams = GetQueryParamsForFullyPay(dateOfPayment, salesPosEquipmentId);
            var resourceUrl = $"{ResourceUrl}/FullyPay/{invoiceId}";
            return PutAsync<bool>(resourceUrl, queryParams, cancellationToken);
        }

        /// <inheritdoc/>
        public Task<ApiResult<IssuedDocumentPaymentGetModel>> PostAsync(IssuedDocumentPaymentPostModel model, CancellationToken cancellationToken = default)
        {
            return PostAsync<IssuedDocumentPaymentPostModel, IssuedDocumentPaymentGetModel>(model, cancellationToken);
        }
    }
}
