using System;
using System.Collections.Generic;
using System.Globalization;
using IdokladSdk.Clients.Interfaces;
using IdokladSdk.Models.IssuedDocumentPayment;
using IdokladSdk.Requests.IssuedDocumentPayment;
using IdokladSdk.Response;

namespace IdokladSdk.Clients
{
    /// <summary>
    /// Client for communication with issued document payment endpoints.
    /// </summary>
    public partial class IssuedDocumentPaymentClient :
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
        public ApiResult<IssuedDocumentPaymentPostModel> Default(int id)
        {
            return Default<IssuedDocumentPaymentPostModel>(id);
        }

        /// <inheritdoc/>
        public ApiResult<bool> Delete(int id)
        {
            return Delete<bool>(id);
        }

        /// <inheritdoc/>
        public IssuedDocumentPaymentDetail Detail(int id)
        {
            return new IssuedDocumentPaymentDetail(id, this);
        }

        /// <inheritdoc/>
        public ApiResult<bool> FullyUnpay(int invoiceId)
        {
            var resourceUrl = $"{ResourceUrl}/FullyUnpay/{invoiceId}";
            return Put<bool>(resourceUrl);
        }

        /// <summary>
        /// Fully pays document.
        /// </summary>
        /// <param name="invoiceId">Id of invoice.</param>
        /// <param name="dateOfPayment">Date of payment.</param>
        /// <param name="salesPosEquipmentId">Sales pos equipment id.</param>
        /// <returns><see cref="ApiResult{TData}"/> instance containing <c>true</c> if full pay was successful, otherwise <c>false</c>.</returns>
        public ApiResult<bool> FullyPay(int invoiceId, DateTime? dateOfPayment = null, int? salesPosEquipmentId = null)
        {
            var queryParams = GetQueryParamsForFullyPay(dateOfPayment, salesPosEquipmentId);
            var resourceUrl = $"{ResourceUrl}/FullyPay/{invoiceId}";
            return Put<bool>(resourceUrl, queryParams);
        }

        /// <inheritdoc/>
        public IssuedDocumentPaymentList List()
        {
            return new IssuedDocumentPaymentList(this);
        }

        /// <inheritdoc/>
        public ApiResult<IssuedDocumentPaymentGetModel> Post(IssuedDocumentPaymentPostModel model)
        {
            return Post<IssuedDocumentPaymentPostModel, IssuedDocumentPaymentGetModel>(model);
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
