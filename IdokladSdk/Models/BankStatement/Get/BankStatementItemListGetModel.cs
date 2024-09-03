using System;
using IdokladSdk.Enums;

namespace IdokladSdk.Models.BankStatement
{
    /// <summary>
    /// BankStatementItemGetModel.
    /// </summary>
    public class BankStatementItemListGetModel : IEntityId
    {
        /// <summary>
        /// Gets or sets constant symbol Id.
        /// </summary>
        [Obsolete("Moved to the Document Header")]
        public int? ConstantSymbolId { get; set; }

        /// <summary>
        /// Gets or sets currency Id.
        /// </summary>
        [Obsolete("Moved to the Document Header")]
        public int CurrencyId { get; set; }

        /// <summary>
        /// Gets or sets Custom VAT rate.
        /// </summary>
        public decimal? CustomVat { get; set; }

        /// <summary>
        /// Gets or sets date of transaction.
        /// </summary>
        [Obsolete("Moved to the Document Header")]
        public DateTime DateOfTransaction { get; set; }

        /// <summary>
        /// Gets or sets exchange rate.
        /// </summary>
        [Obsolete("Moved to the Document Header")]
        public decimal ExchangeRate { get; set; }

        /// <summary>
        /// Gets or sets exchange rate amount.
        /// </summary>
        [Obsolete("Moved to the Document Header")]
        public decimal ExchangeRateAmount { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether item has custom Vat value.
        /// </summary>
        public bool HasCustomVat { get; set; }

        /// <inheritdoc />
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether include subject to income tax.
        /// </summary>
        [Obsolete("Moved to the Document Header")]
        public bool IsIncomeTax { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether is paired.
        /// </summary>
        [Obsolete("Moved to the Document Header")]
        public bool IsPaired { get; set; }

        /// <summary>
        /// Gets or sets issued tax document id.
        /// </summary>
        [Obsolete("Moved to the Document Header")]
        public int? IssuedTaxDocumentId { get; set; }

        /// <summary>
        /// Gets or sets movement type.
        /// </summary>
        [Obsolete("Moved to the Document Header")]
        public MovementType MovementType { get; set; }

        /// <summary>
        /// Gets or sets item name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets account number.
        /// </summary>
        [Obsolete("Moved to the Document Header")]
        public string PartnerAccountNumber { get; set; }

        /// <summary>
        /// Gets or sets four character bank code.
        /// </summary>
        [Obsolete("Moved to the Document Header")]
        public string PartnerBankCode { get; set; }

        /// <summary>
        /// Gets or sets iBAN.
        /// </summary>
        [Obsolete("Moved to the Document Header")]
        public string PartnerIban { get; set; }

        /// <summary>
        /// Gets or sets swift code.
        /// </summary>
        [Obsolete("Moved to the Document Header")]
        public string PartnerSwift { get; set; }

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
        /// Gets or sets specific symbol.
        /// </summary>
        [Obsolete("Moved to the Document Header")]
        public string SpecificSymbol { get; set; }

        /// <summary>
        /// Gets or sets text.
        /// </summary>
        [Obsolete("Moved to the Document Header")]
        public string Text { get; set; }

        /// <summary>
        /// Gets or sets variable symbol.
        /// </summary>
        [Obsolete("Moved to the Document Header")]
        public string VariableSymbol { get; set; }

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

        /// <summary>
        /// Gets or sets Vat regime.
        /// </summary>
        [Obsolete("Moved to the Document Header")]
        public VatRegime VatRegime { get; set; }
    }
}
