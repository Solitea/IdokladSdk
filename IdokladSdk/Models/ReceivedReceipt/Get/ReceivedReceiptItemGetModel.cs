using IdokladSdk.Enums;
using IdokladSdk.Models.Common;

namespace IdokladSdk.Models.ReceivedReceipt.Get
{
    /// <summary>
    /// ReceivedReceiptItemGetModel.
    /// </summary>
    public class ReceivedReceiptItemGetModel
    {
        /// <summary>
        /// Gets or sets the item amount.
        /// </summary>
        public decimal Amount { get; set; }

        /// <summary>
        /// Gets or sets the custom VAT rate.
        /// </summary>
        public decimal? CustomVat { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the item has a custom VAT value.
        /// </summary>
        public bool HasCustomVat { get; set; }

        /// <summary>
        /// Gets or sets the entity's ID.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the item name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the prices and calculations.
        /// </summary>
        public ItemPrices Prices { get; set; }

        /// <summary>
        /// Gets or sets the price type.
        /// </summary>
        public PriceTypeWithoutOnlyBase PriceType { get; set; }

        /// <summary>
        /// Gets or sets the unit of measure.
        /// </summary>
        public string Unit { get; set; }

        /// <summary>
        /// Gets or sets the VAT classification code.
        /// </summary>
        public int? VatCodeId { get; set; }

        /// <summary>
        /// Gets or sets the VAT rate.
        /// </summary>
        public decimal VatRate { get; set; }

        /// <summary>
        /// Gets or sets the VAT rate type.
        /// </summary>
        public VatRateType VatRateType { get; set; }
    }
}
