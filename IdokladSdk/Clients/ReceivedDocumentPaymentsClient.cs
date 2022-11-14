using System;
using System.Collections.Generic;
using System.Globalization;
using System.Threading;
using System.Threading.Tasks;
using IdokladSdk.Clients.Interfaces;
using IdokladSdk.Models.ReceivedDocumentPayments;
using IdokladSdk.Requests.ReceivedDocumentPayments;
using IdokladSdk.Response;

namespace IdokladSdk.Clients
{
    /// <summary>
    /// Client for communication with received document payment endpoints.
    /// </summary>
    public class ReceivedDocumentPaymentsClient :
        BaseClient,
        IDefaultWithIdRequest<ReceivedDocumentPaymentPostModel>,
        IDeleteRequest,
        IEntityDetail<ReceivedDocumentPaymentDetail>,
        IEntityList<ReceivedDocumentPaymentList>,
        IFullyUnpayRequest,
        IPostRequest<ReceivedDocumentPaymentPostModel, ReceivedDocumentPaymentGetModel>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ReceivedDocumentPaymentsClient"/> class.
        /// </summary>
        /// <param name="context">API context.</param>
        public ReceivedDocumentPaymentsClient(ApiContext context)
            : base(context)
        {
        }

        /// <inheritdoc/>
        public override string ResourceUrl => "/ReceivedDocumentPayments";

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
        public ReceivedDocumentPaymentDetail Detail(int id)
        {
            return new ReceivedDocumentPaymentDetail(id, this);
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
        public Task<ApiResult<bool>> FullyUnpayAsync(int invoiceId, CancellationToken cancellationToken = default)
        {
            var resourceUrl = $"{ResourceUrl}/FullyUnpay/{invoiceId}";
            return PutAsync<bool>(resourceUrl, null, cancellationToken);
        }

        /// <inheritdoc/>
        public ReceivedDocumentPaymentList List()
        {
            return new ReceivedDocumentPaymentList(this);
        }

        /// <inheritdoc/>
        public Task<ApiResult<ReceivedDocumentPaymentGetModel>> PostAsync(ReceivedDocumentPaymentPostModel model, CancellationToken cancellationToken = default)
        {
            return PostAsync<ReceivedDocumentPaymentPostModel, ReceivedDocumentPaymentGetModel>(model, cancellationToken);
        }

        private Dictionary<string, string> GetQueryParamsForFullyPay(DateTime? dateOfPayment)
        {
            var queryParams = new Dictionary<string, string>();

            if (dateOfPayment.HasValue)
            {
                queryParams.Add("dateOfPayment", dateOfPayment.Value.ToString(Constants.DateFormat, CultureInfo.InvariantCulture));
            }

            return queryParams;
        }
    }
}
