using IdokladSdk.Enums;

namespace IdokladSdk.Models.BankStatement
{
    /// <summary>
    /// BankStatementItemGetModel.
    /// </summary>
    public class BankStatementItemListGetModel : IEntityId
    {
        /// <summary>
        /// Gets or sets Custom VAT rate.
        /// </summary>
        public decimal? CustomVat { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether item has custom Vat value.
        /// </summary>
        public bool HasCustomVat { get; set; }

        /// <inheritdoc />
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets item name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets Unit price.
        /// </summary>
        public decimal Price { get; set; }

        /// <summary>
        /// Gets or sets prices and calculations.
        /// </summary>
        public BankStatementItemPrices Prices { get; set; }

        /// <summary>
        /// Gets or sets price type.
        /// </summary>
        public PriceType PriceType { get; set; }

        /// <summary>
        /// Gets or sets VAT classification code.
        /// </summary>
        public int? VatCodeId { get; set; }

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
