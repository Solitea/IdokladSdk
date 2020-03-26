using IdokladSdk.Enums;
using IdokladSdk.Models.Common;

namespace IdokladSdk.Models.IssuedInvoice
{
    /// <summary>
    /// IssuedInvoiceItemRecountGetModel.
    /// </summary>
    public class IssuedInvoiceItemRecountGetModel : IEntityId
    {
        /// <summary>
        /// Gets or sets item amount.
        /// </summary>
        public decimal Amount { get; set; }

        /// <summary>
        /// Gets or sets discount on item.
        /// </summary>
        public decimal DiscountPercentage { get; set; }

        /// <inheritdoc/>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets item type.
        /// </summary>
        public IssuedInvoiceItemType ItemType { get; set; }

        /// <summary>
        /// Gets or sets item name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets prices and calculations.
        /// </summary>
        public InvoiceItemPrices Prices { get; set; }

        /// <summary>
        /// Gets or sets price type.
        /// </summary>
        public PriceType PriceType { get; set; }

        /// <summary>
        /// Gets or sets vAT rate in percent.
        /// </summary>
        public decimal VatRate { get; set; }

        /// <summary>
        /// Gets or sets vAT rate type.
        /// </summary>
        public VatRateType VatRateType { get; set; }
    }
}
