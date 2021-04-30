using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using IdokladSdk.Enums;
using IdokladSdk.Validation.Attributes;

namespace IdokladSdk.Models.RecurringInvoice.Get
{
    /// <summary>
    /// InvoiceTemplateCopyGetModel.
    /// </summary>
    public class InvoiceTemplateCopyGetModel
    {
        /// <summary>
        /// Gets or Sets Bank Account Id.
        /// </summary>
        [Required]
        public int BankAccountId { get; set; }

        /// <summary>
        /// Gets or Sets Constant symbol Id.
        /// </summary>
        public int? ConstantSymbolId { get; set; }

        /// <summary>
        /// Gets or Sets Currency Id.
        /// </summary>
        [Required]
        public int CurrencyId { get; set; }

        /// <summary>
        /// Gets or Sets Delivery address id.
        /// </summary>
        public int? DeliveryAddressId { get; set; }

        /// <summary>
        /// Gets or Sets Description.
        /// </summary>
        [Required]
        public string Description { get; set; }

        /// <summary>
        /// Gets or Sets Discount size in percent.
        /// </summary>
        [Range(0.0, 99.99)]
        public decimal DiscountPercentage { get; set; }

        /// <summary>
        /// Gets or Sets Document type.
        /// </summary>
        [Required]
        public RecurringDocumentType DocumentType { get; set; }

        /// <summary>
        /// Gets or Sets Invoice maturity (in days).
        /// </summary>
        [Required]
        public int InvoiceMaturity { get; set; }

        /// <summary>
        /// Gets or Sets a value indicating whether Fixed variable symbol.
        /// </summary>
        public bool IsConstantVariableSymbol { get; set; }

        /// <summary>
        /// Gets or Sets a value indicating whether Attribute for application of VAT based on payments.
        /// </summary>
        public bool IsDocumentInVatOnPay { get; set; }

        /// <summary>
        /// Gets or Sets a value indicating whether Flag indicating whether the document is registered in EET.
        /// </summary>
        [Required]
        public bool IsEet { get; set; }

        /// <summary>
        /// Gets or Sets Invoice items.
        /// </summary>
        [MinCollectionLength(1)]
        [Required]
        public List<InvoiceItemTemplateCopyGetModel> Items { get; set; }

        /// <summary>
        /// Gets or Sets Text Items text prefix.
        /// </summary>
        public string ItemsTextPrefix { get; set; }

        /// <summary>
        /// Gets or Sets Items text suffix.
        /// </summary>
        public string ItemsTextSuffix { get; set; }

        /// <summary>
        /// Gets or Sets Note.
        /// </summary>
        public string Note { get; set; }

        /// <summary>
        /// Gets or Sets Numeric sequence id.
        /// </summary>
        [Required]
        public int NumericSequenceId { get; set; }

        /// <summary>
        /// Gets or Sets Order number.
        /// </summary>
        [StringLength(20)]
        public string OrderNumber { get; set; }

        /// <summary>
        /// Gets or Sets Partner contact id.
        /// </summary>
        [Required]
        public int PartnerId { get; set; }

        /// <summary>
        /// Gets or Sets Payment option id.
        /// </summary>
        [Required]
        public int PaymentOptionId { get; set; }

        /// <summary>
        /// Gets or Sets Language of report.
        /// </summary>
        public Language? ReportLanguage { get; set; }

        /// <summary>
        /// Gets or Sets Setting for date of taxing.
        /// </summary>
        public TaxingType TaxingType { get; set; }

        /// <summary>
        /// Gets or Sets Variable symbol.
        /// </summary>
        [StringLength(10)]
        public string VariableSymbol { get; set; }

        /// <summary>
        /// Gets or Sets Vat reverse charge code id.
        /// </summary>
        public int? VatReverseChargeCodeId { get; set; }
    }
}
