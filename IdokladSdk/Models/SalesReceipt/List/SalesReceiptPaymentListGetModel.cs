using IdokladSdk.Models.Common;

namespace IdokladSdk.Models.SalesReceipt
{
    /// <summary>
    /// SalesReceiptPayment Model for Get list endpoints.
    /// </summary>
    public partial class SalesReceiptPaymentListGetModel : IEntityId
    {
        /// <inheritdoc/>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets Additional information about the entity.
        /// </summary>
        public Metadata Metadata { get; set; }

        /// <summary>
        /// Gets or sets Payment option id.
        /// </summary>
        public int PaymentOptionId { get; set; }

        /// <summary>
        /// Gets or sets Prices and calculations.
        /// </summary>
        public PaymentPrices Prices { get; set; }

        /// <summary>
        /// Gets or sets Payment transaction code.
        /// </summary>
        public string TransactionCode { get; set; }
    }
}
