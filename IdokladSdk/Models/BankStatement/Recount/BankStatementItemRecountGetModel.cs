using IdokladSdk.Enums;
using IdokladSdk.Models.Common;

namespace IdokladSdk.Models.BankStatement.Recount
{
    /// <summary>
    /// BankStatementItemRecountGetModel.
    /// </summary>
    public class BankStatementItemRecountGetModel
    {
        /// <summary>
        /// Gets or sets Custom VAT rate.
        /// </summary>
        public decimal? CustomVat { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether item has custom Vat value.
        /// </summary>
        public bool HasCustomVat { get; set; }

        /// <summary>
        /// Gets or sets The entity's Id.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets Item name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets Prices and calculations.
        /// </summary>
        public ItemPrices Prices { get; set; }

        /// <summary>
        /// Gets or sets Pricelist item id.
        /// </summary>
        public PriceType PriceType { get; set; }

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
