using IdokladSdk.Models.Common;

namespace IdokladSdk.Models.IssuedInvoice
{
    /// <summary>
    /// IssuedInvoicePrices.
    /// </summary>
    public class IssuedInvoicePrices : InvoicePrices
    {
        /// <summary>
        /// Gets or sets total amount of discount. If the invoice is without discount, this will be zero..
        /// </summary>
        public decimal TotalDiscountAmount { get; set; }

        /// <summary>
        /// Gets or sets total amount without discount. If the invoice is without discount, this will be zero..
        /// </summary>
        public decimal TotalWithoutDiscount { get; set; }
    }
}
