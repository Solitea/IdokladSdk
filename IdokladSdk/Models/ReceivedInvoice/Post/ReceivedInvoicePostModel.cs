using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using IdokladSdk.Enums;
using IdokladSdk.Validation.Attributes;

namespace IdokladSdk.Models.ReceivedInvoice
{
    /// <summary>
    /// ReceivedInvoicePostModel.
        /// </summary>
    public class ReceivedInvoicePostModel
    {
        /// <summary>
        /// Gets or sets account number.
        /// </summary>
        [StringLength(50)]
        public string AccountNumber { get; set; }

        /// <summary>
        /// Gets or sets bank id.
        /// </summary>
        [NullableForeignKey]
        public int? BankId { get; set; }

        /// <summary>
        /// Gets or sets currency Id.
        /// </summary>
        [RequiredNonDefault]
        public int CurrencyId { get; set; }

        /// <summary>
        /// Gets or sets date of issue.
        /// </summary>
        public DateTime? DateOfIssue { get; set; }

        /// <summary>
        /// Gets or sets date of maturity.
        /// </summary>
        [DateGreaterOrEqualThan(Constants.DefaultDateTimeString)]
        [Required]
        public DateTime DateOfMaturity { get; set; }

        /// <summary>
        /// Gets or sets date of payment.
        /// </summary>
        public DateTime? DateOfPayment { get; set; }

        /// <summary>
        /// Gets or sets date of receiving.
        /// </summary>
        [DateGreaterOrEqualThan(Constants.DefaultDateTimeString)]
        [Required]
        public DateTime DateOfReceiving { get; set; }

        /// <summary>
        /// Gets or sets date of taxing.
        /// </summary>
        public DateTime? DateOfTaxing { get; set; }

        /// <summary>
        /// Gets or sets date of VAT application.
        /// </summary>
        public DateTime? DateOfVatApplication { get; set; }

        /// <summary>
        /// Gets or sets description.
        /// </summary>
        [Required]
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets document Serial Number.
        /// </summary>
        [Required]
        public int DocumentSerialNumber { get; set; }

        /// <summary>
        /// Gets or sets exchange rate.
        /// </summary>
        public decimal? ExchangeRate { get; set; }

        /// <summary>
        /// Gets or sets exchange rate amount.
        /// </summary>
        public decimal? ExchangeRateAmount { get; set; }

        /// <summary>
        /// Gets or sets iBAN.
        /// </summary>
        [StringLength(50)]
        public string Iban { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether zahrnout doklad do daňového přiznání.
        /// </summary>
        /// <summary xml:lang='en'>
        /// Include subject to income tax.
        /// </summary>
        [Required]
        public bool IsIncomeTax { get; set; }

        /// <summary>
        /// Gets or sets invoice items.
        /// </summary>
        [Required]
        [MinCollectionLength(1)]
        public List<ReceivedInvoiceItemPostModel> Items { get; set; }

        /// <summary>
        /// Gets or sets note.
        /// </summary>
        public string Note { get; set; }

        /// <summary>
        /// Gets or sets order number.
        /// </summary>
        [StringLength(20)]
        public string OrderNumber { get; set; }

        /// <summary>
        /// Gets or sets partner contact id.
        /// </summary>
        [RequiredNonDefault]
        public int PartnerId { get; set; }

        /// <summary>
        /// Gets or sets payment option id.
        /// </summary>
        [RequiredNonDefault]
        public int PaymentOptionId { get; set; }

        /// <summary>
        /// Gets or sets document number of the original document.
        /// </summary>
        [StringLength(30)]
        public string ReceivedDocumentNumber { get; set; }

        /// <summary>
        /// Gets or sets swift code.
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
        /// Gets or sets vat reverse charge code id.
        /// </summary>
        [NullableForeignKey]
        public int? VatReverseChargeCodeId { get; set; }
    }
}
