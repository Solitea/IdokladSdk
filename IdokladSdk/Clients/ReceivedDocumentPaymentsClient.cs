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
        [Obsolete("Use async method instead.")]
        public ApiResult<ReceivedDocumentPaymentPostModel> Default(int id)
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
        [Obsolete("Use async method instead.")]
        public ApiResult<bool> FullyPay(int invoiceId, DateTime? dateOfPayment = null)
        {
            return FullyPayAsync(invoiceId, dateOfPayment).GetAwaiter().GetResult();
        }

        /// <inheritdoc/>
        [Obsolete("Use async method instead.")]
        public ApiResult<bool> FullyUnpay(int invoiceId)
        {
            return FullyUnpayAsync(invoiceId).GetAwaiter().GetResult();
        }

        /// <inheritdoc/>
        public ReceivedDocumentPaymentList List()
        {
            return new ReceivedDocumentPaymentList(this);
        }

        /// <inheritdoc/>
        [Obsolete("Use async method instead.")]
        public ApiResult<ReceivedDocumentPaymentGetModel> Post(ReceivedDocumentPaymentPostModel model)
        {
            return PostAsync(model).GetAwaiter().GetResult();
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
