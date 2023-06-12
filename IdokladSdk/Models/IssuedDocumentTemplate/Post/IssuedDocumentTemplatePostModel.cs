using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using IdokladSdk.Enums;
using IdokladSdk.Validation.Attributes;

namespace IdokladSdk.Models.IssuedDocumentTemplate.Post
{
    /// <summary>
    /// IssuedDocumentTemplatePostModel.
    /// </summary>
    public class IssuedDocumentTemplatePostModel
    {
        /// <summary>
        /// Gets or sets bank account id.
        /// </summary>
        [Required]
        public int BankAccountId { get; set; }

        /// <summary>
        /// Gets or sets constant symbol id.
        /// </summary>
        public int? ConstantSymbolId { get; set; }

        /// <summary>
        /// Gets or sets currency id.
        /// </summary>
        [Required]
        public int CurrencyId { get; set; }

        /// <summary>
        /// Gets or sets delivery address id.
        /// </summary>
        public int? DeliveryAddressId { get; set; }

        /// <summary>
        /// Gets or sets description.
        /// </summary>
        [Required(AllowEmptyStrings = true)]
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets discount percentage.
        /// </summary>
        [Range(0.0, 99.99)]
        public decimal DiscountPercentage { get; set; }

        /// <summary>
        /// Gets or sets document type.
        /// </summary>
        [Required]
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
        /// Gets or sets a value indicating whether is constant exchange rate.
        /// </summary>
        public bool IsConstantExchangeRate { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether is constant variable symbol.
        /// </summary>
        public bool IsConstantVariableSymbol { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether is income tax.
        /// </summary>
        public bool IsIncomeTax { get; set; }

        /// <summary>
        /// Gets or sets items.
        /// </summary>
        [MinCollectionLength(1)]
        [Required]
        public List<IssuedDocumentTemplateItemPostModel> Items { get; set; }

        /// <summary>
        /// Gets or sets items text prefix.
        /// </summary>
        [Required(AllowEmptyStrings = true)]
        public string ItemsTextPrefix { get; set; }

        /// <summary>
        /// Gets or sets items text suffix.
        /// </summary>
        [Required(AllowEmptyStrings = true)]
        public string ItemsTextSuffix { get; set; }

        /// <summary>
        /// Gets or sets name.
        /// </summary>
        [Required]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets numeric sequence id.
        /// </summary>
        [Required]
        public int NumericSequenceId { get; set; }

        /// <summary>
        /// Gets or sets order number.
        /// </summary>
        [StringLength(25)]
        [Required(AllowEmptyStrings = true)]
        public string OrderNumber { get; set; }

        /// <summary>
        /// Gets or sets partner id.
        /// </summary>
        public int? PartnerId { get; set; }

        /// <summary>
        /// Gets or sets payment option id.
        /// </summary>
        [Required]
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
        [StringLength(10)]
        [RequiredIf(nameof(IsConstantVariableSymbol), true)]
        public string VariableSymbol { get; set; }

        /// <summary>
        /// Gets or sets vat reverse charge code id.
        /// </summary>
        public int? VatReverseChargeCodeId { get; set; }
    }
}
