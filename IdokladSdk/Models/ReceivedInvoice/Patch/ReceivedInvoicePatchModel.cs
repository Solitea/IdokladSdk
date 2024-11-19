using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using IdokladSdk.Enums;
using IdokladSdk.Models.Base;
using IdokladSdk.Models.Common;
using IdokladSdk.Validation.Attributes;

namespace IdokladSdk.Models.ReceivedInvoice
{
    /// <summary>
    /// ReceivedInvoicePatchModel.
    /// </summary>
    public class ReceivedInvoicePatchModel : ValidatableModel, IEntityId
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
        [NullableForeignKey]
        public NullableProperty<int> BankId { get; set; }

        /// <summary>
        /// Gets or sets currency id.
        /// </summary>
        [NullableForeignKey]
        public int? CurrencyId { get; set; }

        /// <summary>
        /// Gets or sets date of issue.
        /// </summary>
        [DateGreaterOrEqualThan(Constants.DefaultDateTimeString, true)]
        public NullableProperty<DateTime> DateOfIssue { get; set; }

        /// <summary>
        /// Gets or sets date of maturity.
        /// </summary>
        [DateGreaterOrEqualThan(Constants.DefaultDateTimeString, true)]
        [DateGreaterThanOrEqualThanAnotherDate(nameof(DateOfIssue))]
        public NullableProperty<DateTime> DateOfMaturity { get; set; }

        /// <summary>
        /// Gets or sets date of payment.
        /// </summary>
        public DateTime? DateOfPayment { get; set; }

        /// <summary>
        /// Gets or sets date of receiving.
        /// </summary>
        public DateTime? DateOfReceiving { get; set; }

        /// <summary>
        /// Gets or sets date of taxing. Date of taxable received for SK legislation.
        /// </summary>
        public NullableProperty<DateTime> DateOfTaxing { get; set; }

        /// <summary>
        /// Gets or sets date of VAT application.
        /// </summary>
        public DateTime? DateOfVatApplication { get; set; }

        /// <summary>
        /// Gets or sets description.
        /// </summary>
        [NotEmptyString]
        public string Description { get; set; }

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
        [Iban]
        public string Iban { get; set; }

        /// <inheritdoc/>
        [RequiredNonDefault]
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets include subject to income tax.
        /// </summary>
        public bool? IsIncomeTax { get; set; }

        /// <summary>
        /// Gets or sets invoice items.
        /// </summary>
        public List<ReceivedInvoiceItemPatchModel> Items { get; set; }

        /// <summary>
        /// Gets or sets note.
        /// </summary>
        public string Note { get; set; }

        /// <summary>
        /// Gets or sets order number.
        /// </summary>
        [StringLength(25)]
        public string OrderNumber { get; set; }

        /// <summary>
        /// Gets or sets partner contact id.
        /// </summary>
        [NullableForeignKey]
        public int? PartnerId { get; set; }

        /// <summary>
        /// Gets or sets payment option id.
        /// </summary>
        [NullableForeignKey]
        public int? PaymentOptionId { get; set; }

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
        public VatOnPayStatus? VatOnPayStatus { get; set; }

        /// <summary>
        /// Gets or sets vat reverse charge code id.
        /// </summary>
        [NullableForeignKey]
        public NullableProperty<int> VatReverseChargeCodeId { get; set; }
    }
}
