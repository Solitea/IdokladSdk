using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using IdokladSdk.Enums;
using IdokladSdk.Models.Common;
using IdokladSdk.Models.Contact;

namespace IdokladSdk.Models.IssuedDocumentTemplate.List
{
    /// <summary>
    /// IssuedDocumentTemplateListGetModel.
    /// </summary>
    public class IssuedDocumentTemplateListGetModel
    {
        /// <summary>
        /// Gets or sets bank account id.
        /// </summary>
        public int? BankAccountId { get; set; }

        /// <summary>
        /// Gets or sets constant symbol id.
        /// </summary>
        public int? ConstantSymbolId { get; set; }

        /// <summary>
        /// Gets or sets currency id.
        /// </summary>
        public int? CurrencyId { get; set; }

        /// <summary>
        /// Gets or Sets Partner delivery address id.
        /// </summary>
        public int? DeliveryAddressId { get; set; }

        /// <summary>
        /// Gets or sets description.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets discount size in percent.
        /// </summary>
        public decimal DiscountPercentage { get; set; }

        /// <summary>
        /// Gets or sets document type.
        /// </summary>
        public IssuedDocumentTemplateType DocumentType { get; set; }

        /// <summary>
        /// Gets or sets exchange rate.
        /// </summary>
        public decimal? ExchangeRate { get; set; }

        /// <summary>
        /// Gets or sets exchange rate amount.
        /// </summary>
        public decimal? ExchangeRateAmount { get; set; }

        /// <summary>
        /// Gets or sets id.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets invoice maturity (in days).
        /// </summary>
        public int? InvoiceMaturity { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether fixed exchange rate is used.
        /// </summary>
        public bool IsConstantExchangeRate { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether fixed variable symbol is used.
        /// </summary>
        public bool IsConstantVariableSymbol { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether value indicating whether income tax.
        /// </summary>
        public bool IsIncomeTax { get; set; }

        /// <summary>
        /// Gets or sets invoice items.
        /// </summary>
        public List<IssuedDocumentTemplateListItemGetModel> Items { get; set; }

        /// <summary>
        /// Gets or sets items text prefix.
        /// </summary>
        public string ItemsTextPrefix { get; set; }

        /// <summary>
        /// Gets or sets items text suffix.
        /// </summary>
        public string ItemsTextSuffix { get; set; }

        /// <summary>
        /// Gets or sets metadata.
        /// </summary>
        public Metadata Metadata { get; set; }

        /// <summary>
        /// Gets or sets name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets numeric sequence id.
        /// </summary>
        public int? NumericSequenceId { get; set; }

        /// <summary>
        /// Gets or sets order number.
        /// </summary>
        public string OrderNumber { get; set; }

        /// <summary>
        /// Gets or sets partner.
        /// </summary>
        public ContactGetModel Partner { get; set; }

        /// <summary>
        /// Gets or sets partner id.
        /// </summary>
        public int? PartnerId { get; set; }

        /// <summary>
        /// Gets or sets payment option id.
        /// </summary>
        public int? PaymentOptionId { get; set; }

        /// <summary>
        /// Gets or sets prices and calculations.
        /// </summary>
        public TemplatePrices Prices { get; set; }

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
        /// Gets or sets VAT reverse charge code id.
        /// </summary>
        public int? VatReverseChargeCodeId { get; set; }
    }
}
