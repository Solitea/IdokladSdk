using IdokladSdk.Enums;

namespace IdokladSdk.Models.SalesReceipt.Copy
{
    /// <summary>
    /// SalesReceiptItemCopyGetModel for Copy endpoints.
    /// </summary>
    public class SalesReceiptItemCopyGetModel
    {
        /// <summary>
        /// Gets or sets amount.
        /// </summary>
        public decimal Amount { get; set; }

        /// <summary>
        /// Gets or sets item type.
        /// </summary>
        public SalesReceiptItemType ItemType { get; set; }

        /// <summary>
        /// Gets or sets name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets price list item id.
        /// </summary>
        public int? PriceListItemId { get; set; }

        /// <summary>
        /// Gets or sets price type.
        /// </summary>
        public PriceTypeWithoutOnlyBase PriceType { get; set; }

        /// <summary>
        /// Gets or sets unit.
        /// </summary>
        public string Unit { get; set; }

        /// <summary>
        /// Gets or sets unit price.
        /// </summary>
        public decimal UnitPrice { get; set; }

        /// <summary>
        /// Gets or sets VAT rate type.
        /// </summary>
        public VatRateType VatRateType { get; set; }
    }
}
