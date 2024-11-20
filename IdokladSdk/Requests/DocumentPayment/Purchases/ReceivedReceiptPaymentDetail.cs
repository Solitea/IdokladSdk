using IdokladSdk.Clients;
using IdokladSdk.Models.Payment.DocumentPayments.Purchases.Detail;
using IdokladSdk.Requests.Core;
using IdokladSdk.Requests.Core.Modifiers.Expand.Structure;

namespace IdokladSdk.Requests.DocumentPayment.Purchases
{
    /// <summary>
    /// ReceivedReceiptPaymentDetail.
    /// </summary>
    public class ReceivedReceiptPaymentDetail : ExpandableDetail<ReceivedReceiptPaymentDetail, DocumentPaymentClient,
        PurchaseDocumentPaymentForReceivedReceiptGetModel, PurchaseDocumentPaymentForReceivedReceiptExpand>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ReceivedReceiptPaymentDetail"/> class.
        /// </summary>
        /// <param name="id">Payment id.</param>
        /// <param name="client">Sales receipt payment client.</param>
        public ReceivedReceiptPaymentDetail(int id, DocumentPaymentClient client)
            : base(id, client)
        {
        }

        /// <summary>
        /// Gets detail name.
        /// </summary>
        protected override string DetailName => "Purchase/Get/ReceivedReceipt";
    }
}
