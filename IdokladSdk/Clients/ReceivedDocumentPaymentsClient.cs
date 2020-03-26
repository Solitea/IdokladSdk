using System;
using System.Collections.Generic;
using System.Globalization;
using IdokladSdk.Clients.Interfaces;
using IdokladSdk.Models.ReceivedDocumentPayments;
using IdokladSdk.Requests.ReceivedDocumentPayments;
using IdokladSdk.Response;

namespace IdokladSdk.Clients
{
    /// <summary>
    /// Client for communication with received document payment endpoints.
    /// </summary>
    public partial class ReceivedDocumentPaymentsClient :
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
        public ApiResult<ReceivedDocumentPaymentPostModel> Default(int id)
        {
            return Default<ReceivedDocumentPaymentPostModel>(id);
        }

        /// <inheritdoc/>
        public ApiResult<bool> Delete(int id)
        {
            return Delete<bool>(id);
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
        /// <returns><see cref="ApiResult{TData}"/> instance containing <c>true</c> if full pay was successful, otherwise <c>false</c>.</returns>
        public ApiResult<bool> FullyPay(int invoiceId, DateTime? dateOfPayment = null)
        {
            var queryParams = GetQueryParamsForFullyPay(dateOfPayment);
            var resourceUrl = $"{ResourceUrl}/FullyPay/{invoiceId}";
            return Put<bool>(resourceUrl, queryParams);
        }

        /// <inheritdoc/>
        public ApiResult<bool> FullyUnpay(int invoiceId)
        {
            var resourceUrl = $"{ResourceUrl}/FullyUnpay/{invoiceId}";
            return Put<bool>(resourceUrl);
        }

        /// <inheritdoc/>
        public ReceivedDocumentPaymentList List()
        {
            return new ReceivedDocumentPaymentList(this);
        }

        /// <inheritdoc/>
        public ApiResult<ReceivedDocumentPaymentGetModel> Post(ReceivedDocumentPaymentPostModel model)
        {
            return Post<ReceivedDocumentPaymentPostModel, ReceivedDocumentPaymentGetModel>(model);
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
