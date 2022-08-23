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
        [Obsolete("Use async method instead.")]
        public ApiResult<IssuedDocumentPaymentPostModel> Default(int id)
        {
            return DefaultAsync(id).GetAwaiter().GetResult();
        }

        /// <inheritdoc/>
        [Obsolete("Use async method instead.")]
        public ApiResult<bool> Delete(int id)
        {
            return DeleteAsync(id).GetAwaiter().GetResult();
        }

        /// <inheritdoc/>
        public IssuedDocumentPaymentDetail Detail(int id)
        {
            return new IssuedDocumentPaymentDetail(id, this);
        }

        /// <inheritdoc/>
        [Obsolete("Use async method instead.")]
        public ApiResult<bool> FullyUnpay(int invoiceId)
        {
            return FullyUnpayAsync(invoiceId).GetAwaiter().GetResult();
        }

        /// <summary>
        /// Fully pays document.
        /// </summary>
        /// <param name="invoiceId">Id of invoice.</param>
        /// <param name="dateOfPayment">Date of payment.</param>
        /// <param name="salesPosEquipmentId">Sales pos equipment id.</param>
        /// <returns><see cref="ApiResult{TData}"/> instance containing <c>true</c> if full pay was successful, otherwise <c>false</c>.</returns>
        [Obsolete("Use async method instead.")]
        public ApiResult<bool> FullyPay(int invoiceId, DateTime? dateOfPayment = null, int? salesPosEquipmentId = null)
        {
            return FullyPayAsync(invoiceId, dateOfPayment, salesPosEquipmentId).GetAwaiter().GetResult();
        }

        /// <inheritdoc/>
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
        [Obsolete("Use async method instead.")]
        public ApiResult<IssuedDocumentPaymentGetModel> Post(IssuedDocumentPaymentPostModel model)
        {
            return PostAsync(model).GetAwaiter().GetResult();
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
