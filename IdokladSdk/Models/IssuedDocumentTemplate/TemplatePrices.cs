using IdokladSdk.Models.Common;

namespace IdokladSdk.Models.IssuedDocumentTemplate
{
    /// <summary>
    /// TemplatePrices.
    /// </summary>
    public class TemplatePrices : Prices
    {
        /// <summary>
        /// Gets or sets total discount amount.
        /// </summary>
        public decimal TotalDiscountAmount { get; set; }

        /// <summary>
        /// Gets or sets total without discount.
        /// </summary>
        public decimal TotalWithoutDiscount { get; set; }
    }
}
