using System.ComponentModel.DataAnnotations;
using IdokladSdk.Enums;
using IdokladSdk.Models.Common;

namespace IdokladSdk.Models.ReceivedReceipt.Get
{
    /// <summary>
    /// ReceivedReceiptItemRecountGetModel.
    /// </summary>
    public class ReceivedReceiptItemRecountGetModel : IEntityId
    {
        /// <summary>
        /// Gets or sets the item amount.
        /// </summary>
        [Range(0.0, double.MaxValue)]
        public decimal Amount { get; set; }

        /// <summary>
        /// Gets or sets the custom VAT rate.
        /// </summary>
        public decimal? CustomVat { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the item has a custom VAT value that is not recalculated.
        /// </summary>
        public bool HasCustomVat { get; set; }

        /// <summary>
        /// Gets or sets the entity ID.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the item name.
        /// </summary>
        [StringLength(200)]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the prices and calculations for the item.
        /// </summary>
        public ItemPrices Prices { get; set; }

        /// <summary>
        /// Gets or sets the pricelist item ID.
        /// </summary>
        public PriceTypeWithoutOnlyBase PriceType { get; set; }

        /// <summary>
        /// Gets or sets the VAT rate.
        /// </summary>
        public decimal VatRate { get; set; }

        /// <summary>
        /// Gets or sets the VAT rate type for the item.
        /// </summary>
        public VatRateType VatRateType { get; set; }
    }
}
