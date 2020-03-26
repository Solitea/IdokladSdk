using System;
using IdokladSdk.Enums;

namespace IdokladSdk.Models.BankStatement
{
    /// <summary>
    /// BankStatementItemGetModel.
    /// </summary>
    public class BankStatementItemGetModel : IEntityId
    {
        /// <summary>
        /// Gets or sets constant symbol Id.
        /// </summary>
        public int? ConstantSymbolId { get; set; }

        /// <summary>
        /// Gets or sets currency Id.
        /// </summary>
        public int CurrencyId { get; set; }

        /// <summary>
        /// Gets or sets date of transaction.
        /// </summary>
        public DateTime DateOfTransaction { get; set; }

        /// <summary>
        /// Gets or sets exchange rate.
        /// </summary>
        public decimal ExchangeRate { get; set; }

        /// <summary>
        /// Gets or sets exchange rate amount.
        /// </summary>
        public decimal ExchangeRateAmount { get; set; }

        /// <inheritdoc/>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether is paired.
        /// </summary>
        public bool IsPaired { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether include subject to income tax.
        /// </summary>
        public bool IsIncomeTax { get; set; }

        /// <summary>
        /// Gets or sets movement type.
        /// </summary>
        public MovementType MovementType { get; set; }

        /// <summary>
        /// Gets or sets account number.
        /// </summary>
        public string PartnerAccountNumber { get; set; }

        /// <summary>
        /// Gets or sets four character bank code.
        /// </summary>
        public string PartnerBankCode { get; set; }

        /// <summary>
        /// Gets or sets iBAN.
        /// </summary>
        public string PartnerIban { get; set; }

        /// <summary>
        /// Gets or sets swift code.
        /// </summary>
        public string PartnerSwift { get; set; }

        /// <summary>
        /// Gets or sets prices and calculations.
        /// </summary>
        public BankStatementItemPrices Prices { get; set; }

        /// <summary>
        /// Gets or sets price type.
        /// </summary>
        public PriceType PriceType { get; set; }

        /// <summary>
        /// Gets or sets specific symbol.
        /// </summary>
        public string SpecificSymbol { get; set; }

        /// <summary>
        /// Gets or sets text.
        /// </summary>
        public string Text { get; set; }

        /// <summary>
        /// Gets or sets variable symbol.
        /// </summary>
        public string VariableSymbol { get; set; }

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
