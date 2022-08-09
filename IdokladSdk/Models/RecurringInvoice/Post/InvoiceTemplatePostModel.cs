using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using IdokladSdk.Enums;
using IdokladSdk.Models.Base;
using IdokladSdk.Validation.Attributes;

namespace IdokladSdk.Models.RecurringInvoice
{
    /// <summary>
    /// InvoiceTemplatePostModel.
    /// </summary>
    public class InvoiceTemplatePostModel : ValidatableModel
    {
        /// <summary>
        /// Gets or sets bank Account Id.
        /// </summary>
        [RequiredNonDefault]
        public int BankAccountId { get; set; }

        /// <summary>
        /// Gets or sets currency Id.
        /// </summary>
        [RequiredNonDefault]
        public int CurrencyId { get; set; }

        /// <summary>
        /// Gets or sets constant symbol Id.
        /// </summary>
        [NullableForeignKey]
        public int? ConstantSymbolId { get; set; }

        /// <summary>
        /// Gets or sets description.
        /// </summary>
        [Required]
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets discount size in percent.
        /// </summary>
        [Range(0.0, 99.99)]
        public decimal DiscountPercentage { get; set; }

        /// <summary>
        /// Gets or sets delivery address Id.
        /// </summary>
        [NullableForeignKey]
        public int? DeliveryAddressId { get; set; }

        /// <summary>
        /// Gets or sets document type.
        /// </summary>
        [Required]
        public RecurringDocumentType DocumentType { get; set; }

        /// <summary>
        /// Gets or sets invoice maturity (in days).
        /// </summary>
        [Required]
        public int InvoiceMaturity { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether fixed variable symbol is used.
        /// </summary>
        public bool IsConstantVariableSymbol { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the document is registered in EET.
        /// </summary>
        [Required]
        public bool IsEet { get; set; }

        /// <summary>
        /// Gets or sets invoice items.
        /// </summary>
        [MinCollectionLength(1)]
        [Required]
        public List<InvoiceItemTemplatePostModel> Items { get; set; }

        /// <summary>
        /// Gets or sets items text prefix.
        /// </summary>
        public string ItemsTextPrefix { get; set; }

        /// <summary>
        /// Gets or sets items text suffix.
        /// </summary>
        public string ItemsTextSuffix { get; set; }

        /// <summary>
        /// Gets or sets note.
        /// </summary>
        public string Note { get; set; }

        /// <summary>
        /// Gets or sets numeric sequence Id.
        /// </summary>
        [RequiredNonDefault]
        public int NumericSequenceId { get; set; }

        /// <summary>
        /// Gets or sets order number.
        /// </summary>
        [StringLength(20)]
        public string OrderNumber { get; set; }

        /// <summary>
        /// Gets or sets partner contact Id.
        /// </summary>
        [RequiredNonDefault]
        public int PartnerId { get; set; }

        /// <summary>
        /// Gets or sets payment option Id.
        /// </summary>
        [RequiredNonDefault]
        public int PaymentOptionId { get; set; }

        /// <summary>
        /// Gets or sets setting for date of taxing.
        /// </summary>
        public TaxingType TaxingType { get; set; }

        /// <summary>
        /// Gets or sets variable symbol.
        /// </summary>
        [StringLength(10)]
        [RequiredIf(nameof(IsConstantVariableSymbol), true)]
        public string VariableSymbol { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether application of VAT is based on payments.
        /// </summary>
        public bool IsDocumentInVatOnPay { get; set; }

        /// <summary>
        /// Gets or sets VAT reverse charge code Id.
        /// </summary>
        [NullableForeignKey]
        public int? VatReverseChargeCodeId { get; set; }

        /// <summary>
        /// Gets or sets report language.
        /// </summary>
        public Language? ReportLanguage { get; set; }
    }
}
