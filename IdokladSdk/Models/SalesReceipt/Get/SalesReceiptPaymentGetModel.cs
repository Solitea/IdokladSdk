using IdokladSdk.Models.ReadOnly.PaymentOption;

namespace IdokladSdk.Models.SalesReceipt
{
    /// <summary>
    /// SalesReceiptPayment Model for Get endpoints.
    /// </summary>
    public class SalesReceiptPaymentGetModel : SalesReceiptPaymentListGetModel
    {
        /// <summary>
        /// Gets or sets paymentOption.
        /// </summary>
        public PaymentOptionGetModel PaymentOption { get; set; }
    }
}
