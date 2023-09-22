using System.Collections.Generic;
using IdokladSdk.Enums;

namespace IdokladSdk.Models.IssuedDocumentTemplate.Copy
{
    /// <summary>
    /// IssuedDocumentTemplateCopyGetModel.
    /// </summary>
    public class IssuedDocumentTemplateCopyGetModel
    {
        /// <summary>
        /// Gets or sets bank account id.
        /// </summary>
        public int BankAccountId { get; set; }

        /// <summary>
        /// Gets or sets constant symbol id.
        /// </summary>
        public int? ConstantSymbolId { get; set; }

        /// <summary>
        /// Gets or sets currency id.
        /// </summary>
        public int CurrencyId { get; set; }

        /// <summary>
        /// Gets or sets delivery address id.
        /// </summary>
        public int? DeliveryAddressId { get; set; }

        /// <summary>
        /// Gets or sets description.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets discount percentage.
        /// </summary>
        public decimal DiscountPercentage { get; set; }

        /// <summary>
        /// Gets or sets document type.
        /// </summary>
        public IssuedDocumentTemplateType DocumentType { get; set; }

        /// <summary>
        /// Gets or sets exchange rate.
        /// </summary>
        public decimal ExchangeRate { get; set; }

        /// <summary>
        /// Gets or sets exchange rate amount.
        /// </summary>
        public decimal ExchangeRateAmount { get; set; }

        /// <summary>
        /// Gets or sets invoice maturity.
        /// </summary>
        public short? InvoiceMaturity { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether exchange rate is constant.
        /// </summary>
        public bool IsConstantExchangeRate { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether variable symbol is constant.
        /// </summary>
        public bool IsConstantVariableSymbol { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether include subject to income tax.
        /// </summary>
        public bool IsIncomeTax { get; set; }

        /// <summary>
        /// Gets or sets items.
        /// </summary>
        public List<IssuedDocumentTemplateItemCopyGetModel> Items { get; set; }

        /// <summary>
        /// Gets or sets item text prefix.
        /// </summary>
        public string ItemsTextPrefix { get; set; }

        /// <summary>
        /// Gets or sets item text suffix.
        /// </summary>
        public string ItemsTextSuffix { get; set; }

        /// <summary>
        /// Gets or sets name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets numeric sequence id.
        /// </summary>
        public int NumericSequenceId { get; set; }

        /// <summary>
        /// Gets or sets order number.
        /// </summary>
        public string OrderNumber { get; set; }

        /// <summary>
        /// Gets or sets partner id.
        /// </summary>
        public int? PartnerId { get; set; }

        /// <summary>
        /// Gets or sets payment option id.
        /// </summary>
        public int PaymentOptionId { get; set; }

        /// <summary>
        /// Gets or sets report language.
        /// </summary>
        public Language? ReportLanguage { get; set; }

        /// <summary>
        /// Gets or sets validity days.
        /// </summary>
        public int? ValidityDays { get; set; }

        /// <summary>
        /// Gets or sets variable symbol.
        /// </summary>
        public string VariableSymbol { get; set; }

        /// <summary>
        /// Gets or sets vat reverse charge code id.
        /// </summary>
        public int? VatReverseChargeCodeId { get; set; }
    }
}
