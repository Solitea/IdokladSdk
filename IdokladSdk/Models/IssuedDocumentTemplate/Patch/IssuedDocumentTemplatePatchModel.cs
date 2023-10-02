using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using IdokladSdk.Enums;
using IdokladSdk.Models.Base;
using IdokladSdk.Models.Common;
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
        [RequiredIf(nameof(DocumentType), IssuedDocumentTemplateType.IssuedInvoice)]
        [RequiredIf(nameof(DocumentType), IssuedDocumentTemplateType.ProformaInvoice)]
        public NullableProperty<int> ConstantSymbolId { get; set; }

        /// <summary>
        /// Gets or sets currency Id.
        /// </summary>
        public int? CurrencyId { get; set; }

        /// <summary>
        /// Gets or sets delivery address id.
        /// </summary>
        [NullableForeignKey]
        public NullableProperty<int> DeliveryAddressId { get; set; }

        /// <summary>
        /// Gets or sets description.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets discount size in percent.
        /// </summary>
        [RangeNullable(0.0, 99.99)]
        [CannotEqualIf(0.0, nameof(DocumentType), IssuedDocumentTemplateType.SalesOrder)]
        public NullableProperty<decimal> DiscountPercentage { get; set; }

        /// <summary>
        /// Gets or sets document type.
        /// </summary>
        public NullableProperty<IssuedDocumentTemplateType> DocumentType { get; set; }

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
        [NullIf(nameof(DocumentType), IssuedDocumentTemplateType.SalesOrder)]
        [RequiredIf(nameof(DocumentType), IssuedDocumentTemplateType.IssuedInvoice)]
        [RequiredIf(nameof(DocumentType), IssuedDocumentTemplateType.ProformaInvoice)]
        public NullableProperty<int> InvoiceMaturity { get; set; }

        /// <summary>
        /// Gets or sets fixed exchange rate.
        /// </summary>
        public bool? IsConstantExchangeRate { get; set; }

        /// <summary>
        /// Gets or sets fixed variable symbol.
        /// </summary>
        [CannotEqualIf(true, nameof(DocumentType), IssuedDocumentTemplateType.SalesOrder)]
        public NullableProperty<bool> IsConstantVariableSymbol { get; set; }

        /// <summary xml:lang='en'>
        /// Gets or sets include subject to income tax.
        /// </summary>
        [CannotEqualIf(true, nameof(DocumentType), IssuedDocumentTemplateType.SalesOrder)]
        public NullableProperty<bool> IsIncomeTax { get; set; }

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
        [NullableForeignKey]
        public NullableProperty<int> PartnerId { get; set; }

        /// <summary>
        /// Gets or sets payment option id.
        /// </summary>
        public int? PaymentOptionId { get; set; }

        /// <summary>
        /// Gets or sets language of report.
        /// </summary>
        [RequiredIf(nameof(DocumentType), IssuedDocumentTemplateType.IssuedInvoice)]
        [RequiredIf(nameof(DocumentType), IssuedDocumentTemplateType.ProformaInvoice)]
        public NullableProperty<Language> ReportLanguage { get; set; }

        /// <summary>
        /// Gets or sets number of days SalesOrder is valid to.
        /// </summary>
        [NullIf(nameof(DocumentType), IssuedDocumentTemplateType.IssuedInvoice)]
        [NullIf(nameof(DocumentType), IssuedDocumentTemplateType.ProformaInvoice)]
        [RequiredIf(nameof(DocumentType), IssuedDocumentTemplateType.SalesOrder)]
        public NullableProperty<int> ValidityDays { get; set; }

        /// <summary>
        /// Gets or sets variable symbol.
        /// </summary>
        [StringLength(10)]
        [RequiredIf(nameof(IsConstantVariableSymbol), true)]
        [NullOrEmptyStringIf(nameof(DocumentType), IssuedDocumentTemplateType.SalesOrder)]
        public string VariableSymbol { get; set; }

        /// <summary>
        /// Gets or sets vat reverse charge code id.
        /// </summary>
        public int? VatReverseChargeCodeId { get; set; }
    }
}
