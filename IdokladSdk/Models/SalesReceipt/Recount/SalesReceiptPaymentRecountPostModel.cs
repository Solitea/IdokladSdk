using IdokladSdk.Validation.Attributes;

namespace IdokladSdk.Models.SalesReceipt
{
    /// <summary>
    /// SalesReceiptPayment Model for Post recount endpoints.
    /// </summary>
    public class SalesReceiptPaymentRecountPostModel
    {
        /// <summary>
        /// Gets or sets payment option id.
        /// </summary>
        [RequiredNonDefault]
        public int PaymentOptionId { get; set; }
    }
}
