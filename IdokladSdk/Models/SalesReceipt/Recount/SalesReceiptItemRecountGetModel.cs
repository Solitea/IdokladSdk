using IdokladSdk.Enums;
using IdokladSdk.Models.Common;

namespace IdokladSdk.Models.SalesReceipt
{
    /// <summary>
    /// SalesReceiptItem model for Recount Get endpoint.
    /// </summary>
    public class SalesReceiptItemRecountGetModel : IEntityId
    {
        /// <summary>
        /// Gets or sets Amount/number of items.
        /// </summary>
        public decimal Amount { get; set; }

        /// <inheritdoc/>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets prices.
        /// </summary>
        public ItemPrices Prices { get; set; }

        /// <summary>
        /// Gets or sets Price type.
        /// </summary>
        public PriceTypeWithoutOnlyBase PriceType { get; set; }

        /// <summary>
        /// Gets or sets Vat rate.
        /// </summary>
        public decimal VatRate { get; set; }

        /// <summary>
        /// Gets or sets Vat rate type.
        /// </summary>
        public VatRateType VatRateType { get; set; }

        /// <summary>
        /// Gets or sets item type.
        /// </summary>
        public SalesReceiptItemType ItemType { get; set; }
    }
}
