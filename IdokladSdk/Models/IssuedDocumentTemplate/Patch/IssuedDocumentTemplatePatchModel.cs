using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using IdokladSdk.Enums;
using IdokladSdk.Models.Base;
using IdokladSdk.Validation.Attributes;

namespace IdokladSdk.Models.IssuedDocumentTemplate.Patch
{
    /// <summary>
    /// IssuedDocumentTemplatePatchModel.
    /// </summary>
    public class IssuedDocumentTemplatePatchModel : ValidatableModel
    {
        /// <summary>
        /// Gets or sets bank Account Id.
        /// </summary>
        public int? BankAccountId { get; set; }

        /// <summary>
        /// Gets or sets constant symbol Id.
        /// </summary>
        public int? ConstantSymbolId { get; set; }

        /// <summary>
        /// Gets or sets currency Id.
        /// </summary>
        public int? CurrencyId { get; set; }

        /// <summary>
        /// Gets or sets delivery address id.
        /// </summary>
        public int? DeliveryAddressId { get; set; }

        /// <summary>
        /// Gets or sets description.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets discount size in percent.
        /// </summary>
        [Range(0.0, 99.99)]
        public decimal? DiscountPercentage { get; set; }

        /// <summary>
        /// Gets or sets document type.
        /// </summary>
        public IssuedDocumentTemplateType? DocumentType { get; set; }

        /// <summary>
        /// Gets or sets exchange rate.
        /// </summary>
        public decimal? ExchangeRate { get; set; }

        /// <summary>
        /// Gets or sets exchange rate amount.
        /// </summary>
        public decimal? ExchangeRateAmount { get; set; }

        /// <summary>
        /// Gets or sets the entity's Id.
        /// </summary>
        [Required]
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets invoice maturity (in days).
        /// </summary>
        public short? InvoiceMaturity { get; set; }

        /// <summary>
        /// Gets or sets fixed exchange rate.
        /// </summary>
        public bool? IsConstantExchangeRate { get; set; }

        /// <summary>
        /// Gets or sets fixed variable symbol.
        /// </summary>
        public bool? IsConstantVariableSymbol { get; set; }

        /// <summary xml:lang='en'>
        /// Gets or sets include subject to income tax.
        /// </summary>
        public bool? IsIncomeTax { get; set; }

        /// <summary>
        ///  Gets or sets items.
        /// </summary>
        public List<IssuedDocumentTemplateItemPatchModel> Items { get; set; }

        /// <summary>
        /// Gets or sets items text prefix.
        /// </summary>
        public string ItemsTextPrefix { get; set; }

        /// <summary>
        /// Gets or sets items text suffix.
        /// </summary>
        public string ItemsTextSuffix { get; set; }

        /// <summary>
        /// Gets or sets name.
        /// </summary>
        [StringLength(200)]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets numeric sequence id.
        /// </summary>
        public int? NumericSequenceId { get; set; }

        /// <summary>
        /// Gets or sets order number.
        /// </summary>
        [StringLength(25)]
        public string OrderNumber { get; set; }

        /// <summary>
        /// Gets or sets partner contact id.
        /// </summary>
        public int? PartnerId { get; set; }

        /// <summary>
        /// Gets or sets payment option id.
        /// </summary>
        public int? PaymentOptionId { get; set; }

        /// <summary>
        /// Gets or sets language of report.
        /// </summary>
        public Language? ReportLanguage { get; set; }

        /// <summary>
        /// Gets or sets number of days SalesOrder is valid to.
        /// </summary>
        public int? ValidityDays { get; set; }

        /// <summary>
        /// Gets or sets variable symbol.
        /// </summary>
        [StringLength(10)]
        [RequiredIf(nameof(IsConstantVariableSymbol), true)]
        public string VariableSymbol { get; set; }

        /// <summary>
        /// Gets or sets vat reverse charge code id.
        /// </summary>
        public int? VatReverseChargeCodeId { get; set; }
    }
}
