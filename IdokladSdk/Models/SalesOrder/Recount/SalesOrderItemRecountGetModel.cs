using IdokladSdk.Enums;
using IdokladSdk.Models.Common;

namespace IdokladSdk.Models.SalesOrder
{
    /// <summary>
    /// SalesOrderItem Model for Get recount endpoints.
    /// </summary>
    public class SalesOrderItemRecountGetModel : IEntityId
    {
        /// <summary>
        /// Gets or sets item amount.
        /// </summary>
        public decimal Amount { get; set; }

        /// <inheritdoc/>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets item type.
        /// </summary>
        public SalesOrderItemType ItemType { get; set; }

        /// <summary>
        /// Gets or sets item name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets prices and calculations.
        /// </summary>
        public ItemPrices Prices { get; set; }

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
