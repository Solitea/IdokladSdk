using System;
using System.Collections.Generic;
using System.Globalization;
using System.Threading;
using System.Threading.Tasks;
using IdokladSdk.Clients.Interfaces;
using IdokladSdk.Models.IssuedDocumentPayment;
using IdokladSdk.Requests.IssuedDocumentPayment;
using IdokladSdk.Response;

namespace IdokladSdk.Clients
{
    /// <summary>
    /// Client for communication with issued document payment endpoints.
    /// </summary>
    public class IssuedDocumentPaymentClient :
        BaseClient,
        IDefaultWithIdRequest<IssuedDocumentPaymentPostModel>,
        IDeleteRequest,
        IFullyUnpayRequest,
        IEntityDetail<IssuedDocumentPaymentDetail>,
        IEntityList<IssuedDocumentPaymentList>,
        IPostRequest<IssuedDocumentPaymentPostModel, IssuedDocumentPaymentGetModel>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="IssuedDocumentPaymentClient"/> class.
        /// </summary>
        /// <param name="apiContext">API context.</param>
        public IssuedDocumentPaymentClient(ApiContext apiContext)
            : base(apiContext)
        {
        }

        /// <inheritdoc/>
        public override string ResourceUrl { get; } = "/IssuedDocumentPayments";

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
        public IssuedDocumentPaymentDetail Detail(int id)
        {
            return new IssuedDocumentPaymentDetail(id, this);
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
        /// <param name="salesPosEquipmentId">Sales pos equipment id.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns><see cref="ApiResult{TData}"/> instance containing <c>true</c> if full pay was successful, otherwise <c>false</c>.</returns>
        public Task<ApiResult<bool>> FullyPayAsync(int invoiceId, DateTime? dateOfPayment = null, int? salesPosEquipmentId = null, CancellationToken cancellationToken = default)
        {
            var queryParams = GetQueryParamsForFullyPay(dateOfPayment, salesPosEquipmentId);
            var resourceUrl = $"{ResourceUrl}/FullyPay/{invoiceId}";
            return PutAsync<bool>(resourceUrl, queryParams, cancellationToken);
        }

        /// <inheritdoc/>
        [Obsolete("Use DocumentPaymentClient.DocumentPaymentClient.Sales methods instead")]
        public IssuedDocumentPaymentList List()
        {
            return new IssuedDocumentPaymentList(this);
        }

        /// <summary>
        /// Returns list of positive payments which have not issued tax document.
        /// </summary>
        /// <returns><see cref="PaymentsForIssuedTaxDocumentGetModel"/> instance containing positive payments without issued tax document.</returns>
        public PaymentsForIssuedTaxDocumentList PaymentsForIssuedTaxDocument()
        {
            return new PaymentsForIssuedTaxDocumentList(this);
        }

        /// <inheritdoc/>
        public Task<ApiResult<IssuedDocumentPaymentGetModel>> PostAsync(IssuedDocumentPaymentPostModel model, CancellationToken cancellationToken = default)
        {
            return PostAsync<IssuedDocumentPaymentPostModel, IssuedDocumentPaymentGetModel>(model, cancellationToken);
        }

        private Dictionary<string, string> GetQueryParamsForFullyPay(DateTime? dateOfPayment, int? salesPosEquipmentId)
        {
            var queryParams = new Dictionary<string, string>();
            if (dateOfPayment.HasValue)
            {
                queryParams.Add("dateOfPayment", dateOfPayment.Value.ToString(Constants.DateFormat, CultureInfo.InvariantCulture));
            }

            if (salesPosEquipmentId.HasValue)
            {
                queryParams.Add("salesPosEquipmentId", salesPosEquipmentId.Value.ToString(CultureInfo.InvariantCulture));
            }

            return queryParams;
        }
    }
}
