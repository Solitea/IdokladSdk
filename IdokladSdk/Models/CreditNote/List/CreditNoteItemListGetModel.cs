using IdokladSdk.Enums;
using IdokladSdk.Models.Common;

namespace IdokladSdk.Models.CreditNote
{
    /// <summary>
    /// CreditNoteItemListGetModel.
    /// </summary>
    public class CreditNoteItemListGetModel : IEntityId
    {
        /// <summary>
        /// Gets or sets item amount.
        /// </summary>
        public decimal Amount { get; set; }

        /// <summary>
        /// Gets or sets item code.
        /// </summary>
        public string Code { get; set; }

        /// <summary>
        /// Gets or sets discount name.
        /// </summary>
        public string DiscountName { get; set; }

        /// <summary>
        /// Gets or sets discount on item.
        /// </summary>
        public decimal DiscountPercentage { get; set; }

        /// <inheritdoc/>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the item is a tax movement.
        /// </summary>
        public bool IsTaxMovement { get; set; }

        /// <summary>
        /// Gets or sets item type.
        /// </summary>
        public IssuedInvoiceItemType ItemType { get; set; }

        /// <summary>
        /// Gets or sets item name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets price list item id.
        /// </summary>
        public int? PriceListItemId { get; set; }

        /// <summary>
        /// Gets or sets prices and calculations.
        /// </summary>
        public ItemPrices Prices { get; set; }

        /// <summary>
        /// Gets or sets price type.
        /// </summary>
        public PriceType PriceType { get; set; }

        /// <summary>
        /// Gets or sets unit of measure.
        /// </summary>
        public string Unit { get; set; }

        /// <summary>
        /// Gets or sets VAT classification code.
        /// </summary>
        public int? VatCodeId { get; set; }

        /// <summary>
        /// Gets or sets VAT rate in percent.
        /// </summary>
        public decimal VatRate { get; set; }

        /// <summary>
        /// Gets or sets VAT rate type.
        /// </summary>
        public VatRateType VatRateType { get; set; }
    }
}
