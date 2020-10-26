using IdokladSdk.Enums;
using IdokladSdk.Models.Common;

namespace IdokladSdk.Models.SalesReceipt
{
    /// <summary>
    /// SalesReceiptItem Model for Get list endpoints.
    /// </summary>
    public partial class SalesReceiptItemListGetModel : IEntityId
    {
        /// <summary>
        /// Gets or sets amount.
        /// </summary>
        public decimal Amount { get; set; }

        /// <summary>
        /// Gets or sets cash voucher id. Is not null in case of an accounted sales receipt.
        /// </summary>
        public int? CashVoucherItemId { get; set; }

        /// <inheritdoc/>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets item type.
        /// </summary>
        public SalesReceiptItemType ItemType { get; set; }

        /// <summary>
        /// Gets or sets name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets pricelist item id.
        /// </summary>
        public int? PriceListItemId { get; set; }

        /// <summary>
        /// Gets or sets prices.
        /// </summary>
        public ItemPrices Prices { get; set; }

        /// <summary>
        /// Gets or sets price type.
        /// </summary>
        public PriceTypeWithoutOnlyBase PriceType { get; set; }

        /// <summary>
        /// Gets or sets unit.
        /// </summary>
        public string Unit { get; set; }

        /// <summary>
        /// Gets or sets vat rate.
        /// </summary>
        public decimal VatRate { get; set; }

        /// <summary>
        /// Gets or sets vatRateType.
        /// </summary>
        public VatRateType VatRateType { get; set; }
    }
}
