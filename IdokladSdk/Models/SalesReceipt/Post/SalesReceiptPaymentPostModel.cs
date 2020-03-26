using System.ComponentModel.DataAnnotations;
using IdokladSdk.Validation.Attributes;

namespace IdokladSdk.Models.SalesReceipt
{
    /// <summary>
    /// SalesReceiptPayment model for Post endpoints.
    /// </summary>
    public class SalesReceiptPaymentPostModel
    {
        /// <summary>
        /// Gets or sets amount.
        /// </summary>
        public decimal PaymentAmount { get; set; }

        /// <summary>
        /// Gets or sets payment option id.
        /// </summary>
        [RequiredNonDefault]
        public int PaymentOptionId { get; set; }

        /// <summary>
        /// Gets or sets payment transaction code.
        /// </summary>
        [Required(AllowEmptyStrings = true)]
        [StringLength(20)]
        public string PaymentTransactionCode { get; set; }
    }
}
