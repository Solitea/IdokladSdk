using IdokladSdk.Enums;
using IdokladSdk.Models.Common;

namespace IdokladSdk.Models.PriceListItem
{
    /// <summary>
    /// PriceListItemListGetModel.
    /// </summary>
    public class PriceListItemListGetModel : IEntityId
    {
        /// <summary>
        /// Gets or sets amount.
        /// </summary>
        public decimal Amount { get; set; }

        /// <summary>
        /// Gets or sets bar code.
        /// </summary>
        public string BarCode { get; set; }

        /// <summary>
        /// Gets or sets code.
        /// </summary>
        public string Code { get; set; }

        /// <summary>
        /// Gets or sets currency id.
        /// </summary>
        public int CurrencyId { get; set; }

        /// <inheritdoc/>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether item is stock item.
        /// </summary>
        public bool IsStockItem { get; set; }

        /// <summary>
        /// Gets or sets additional information about the entity.
        /// </summary>
        public Metadata Metadata { get; set; }

        /// <summary>
        /// Gets or sets name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets unit price.
        /// </summary>
        public decimal Price { get; set; }

        /// <summary>
        /// Gets or sets price type.
        /// </summary>
        public PriceType PriceType { get; set; }

        /// <summary>
        /// Gets or sets stock balance.
        /// </summary>
        public decimal StockBalance { get; set; }

        /// <summary>
        /// Gets or sets unit of measure.
        /// </summary>
        public string Unit { get; set; }

        /// <summary>
        /// Gets or sets VAT rate type.
        /// </summary>
        public VatRateType VatRateType { get; set; }
    }
}
