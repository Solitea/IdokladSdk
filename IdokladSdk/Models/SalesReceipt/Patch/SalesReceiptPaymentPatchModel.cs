using System.ComponentModel.DataAnnotations;
using IdokladSdk.Validation.Attributes;

namespace IdokladSdk.Models.SalesReceipt
{
    /// <summary>
    /// SalesReceiptPayment model for Patch endpoints.
    /// </summary>
    public class SalesReceiptPaymentPatchModel : IEntityId
    {
        /// <inheritdoc/>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets Payment amount.
        /// </summary>
        public decimal? PaymentAmount { get; set; }

        /// <summary>
        /// Gets or sets Payment option id.
        /// </summary>
        [NullableForeignKey]
        public int? PaymentOptionId { get; set; }

        /// <summary>
        /// Gets or sets Payment transaction code.
        /// </summary>
        [Required(AllowEmptyStrings = true)]
        [StringLength(20)]
        public string PaymentTransactionCode { get; set; }
    }
}
