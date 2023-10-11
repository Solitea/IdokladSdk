using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using IdokladSdk.Enums;
using IdokladSdk.Models.Base;
using IdokladSdk.Validation.Attributes;

namespace IdokladSdk.Models.CreditNote
{
    /// <summary>
    /// CreditNotePostModel.
    /// </summary>
    public class CreditNotePostModel : ValidatableModel
    {
        /// <summary>
        /// Gets or sets account number.
        /// </summary>
        [StringLength(50)]
        [BankAccountNumber]
        public string AccountNumber { get; set; }

        /// <summary>
        /// Gets or sets bank id.
        /// </summary>
        public int? BankId { get; set; }

        /// <summary>
        /// Gets or sets constant symbol Id.
        /// </summary>
        public int? ConstantSymbolId { get; set; }

        /// <summary>
        /// Gets or sets Id of the credited invoice.
        /// </summary>
        [Required]
        public int CreditedInvoiceId { get; set; }

        /// <summary>
        /// Gets or sets reason for issuing a credit note.
        /// </summary>
        [Required(AllowEmptyStrings = false)]
        public string CreditNoteReason { get; set; }

        /// <summary>
        /// Gets or sets currency Id.
        /// </summary>
        [Required]
        public int CurrencyId { get; set; }

        /// <summary>
        /// Gets or sets date of issue.
        /// </summary>
        [Required]
        [DateGreaterOrEqualThan(Constants.DefaultDateTimeString)]
        public DateTime DateOfIssue { get; set; }

        /// <summary>
        /// Gets or sets date of maturity.
        /// </summary>
        [Required]
        [DateGreaterOrEqualThan(Constants.DefaultDateTimeString)]
        [DateGreaterThanOrEqualThanAnotherDate(nameof(DateOfIssue))]
        public DateTime DateOfMaturity { get; set; }

        /// <summary>
        /// Gets or sets date of payment.
        /// </summary>
        public DateTime? DateOfPayment { get; set; }

        /// <summary>
        /// Gets or sets date of taxing.
        /// </summary>
        [Required]
        [DateGreaterOrEqualThan(Constants.DefaultDateTimeString)]
        public DateTime DateOfTaxing { get; set; }

        /// <summary>
        /// Gets or sets date of VAT application.
        /// </summary>
        [DateGreaterOrEqualThan(Constants.DefaultDateTimeString)]
        public DateTime DateOfVatApplication { get; set; }

        /// <summary>
        /// Gets or sets date of VAT claim.
        /// </summary>
        [DateGreaterOrEqualThan(Constants.DefaultDateTimeString, true)]
        [DateGreaterThanOrEqualThanAnotherDate(nameof(DateOfIssue))]
        public DateTime? DateOfVatClaim { get; set; }

        /// <summary>
        /// Gets or sets delivery address Id.
        /// </summary>
        [NullableForeignKey]
        public int? DeliveryAddressId { get; set; }

        /// <summary>
        /// Gets or sets description.
        /// </summary>
        [Required]
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets discount.
        /// </summary>
        [Range(0.0, 99.99)]
        public decimal DiscountPercentage { get; set; }

        /// <summary>
        /// Gets or sets document serial number.
        /// </summary>
        [Required]
        public int DocumentSerialNumber { get; set; }

        /// <summary>
        /// Gets or sets responsibility for handling of electronic records of sales.
        /// </summary>
        public EetResponsibility EetResponsibility { get; set; }

        /// <summary>
        /// Gets or sets exchange rate.
        /// </summary>
        public decimal? ExchangeRate { get; set; }

        /// <summary>
        /// Gets or sets exchange rate amount.
        /// </summary>
        public decimal? ExchangeRateAmount { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether OSS regime is set on invoice.
        /// </summary>
        public bool HasVatRegimeOss { get; set; }

        /// <summary>
        /// Gets or sets IBAN.
        /// </summary>
        [StringLength(50)]
        public string Iban { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the document is registered in EET.
        /// </summary>
        [Required]
        public bool IsEet { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether to include a document to income tax.
        /// </summary>
        [Required]
        public bool IsIncomeTax { get; set; }

        /// <summary>
        /// Gets or sets items.
        /// </summary>
        [MinCollectionLength(1)]
        [Required]
        public List<CreditNoteItemPostModel> Items { get; set; }

        /// <summary>
        /// Gets or sets items text prefix.
        /// </summary>
        public string ItemsTextPrefix { get; set; }

        /// <summary>
        /// Gets or sets items text suffix.
        /// </summary>
        public string ItemsTextSuffix { get; set; }

        /// <summary>
        /// Gets or sets your note for the document.
        /// </summary>
        public string Note { get; set; }

        /// <summary>
        /// Gets or sets note for document.
        /// </summary>
        [Obsolete("This field has been merged with Note field.")]
        public string NoteForCreditNote { get; set; }

        /// <summary>
        /// Gets or sets numeric sequence id.
        /// </summary>
        [Required]
        public int NumericSequenceId { get; set; }

        /// <summary>
        /// Gets or sets order number.
        /// </summary>
        [StringLength(25)]
        public string OrderNumber { get; set; }

        /// <summary>
        /// Gets or sets partner contact id.
        /// </summary>
        [Required]
        public int PartnerId { get; set; }

        /// <summary>
        /// Gets or sets payment option id.
        /// </summary>
        [Required]
        public int PaymentOptionId { get; set; }

        /// <summary>
        /// Gets or sets language of report.
        /// </summary>
        public Language? ReportLanguage { get; set; }

        /// <summary>
        /// Gets or sets POS equipment id.
        /// </summary>
        public int? SalesPosEquipmentId { get; set; }

        /// <summary>
        /// Gets or sets Swift code.
        /// </summary>
        [StringLength(11)]
        public string Swift { get; set; }

        /// <summary>
        /// Gets or sets tags.
        /// </summary>
        public List<int> Tags { get; set; }

        /// <summary>
        /// Gets or sets variable symbol.
        /// </summary>
        [StringLength(10)]
        public string VariableSymbol { get; set; }

        /// <summary>
        /// Gets or sets attribute for application of VAT based on payments.
        /// </summary>
        public VatOnPayStatus VatOnPayStatus { get; set; }

        /// <summary>
        /// Gets or sets VAT reverse charge code id.
        /// </summary>
        public int? VatReverseChargeCodeId { get; set; }
    }
}
