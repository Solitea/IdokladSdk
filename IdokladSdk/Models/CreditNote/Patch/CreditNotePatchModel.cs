using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using IdokladSdk.Enums;
using IdokladSdk.Models.Base;
using IdokladSdk.Models.Common;
using IdokladSdk.Models.DocumentAddress;
using IdokladSdk.Validation.Attributes;

namespace IdokladSdk.Models.CreditNote
{
    /// <summary>
    /// CreditNotePatchModel.
    /// </summary>
    public class CreditNotePatchModel : ValidatableModel, IEntityId
    {
        /// <summary>
        /// Gets or sets constant symbol Id.
        /// </summary>
        public int? ConstantSymbolId { get; set; }

        /// <summary>
        /// Gets or sets reason for issuing a credit note.
        /// </summary>
        public string CreditNoteReason { get; set; }

        /// <summary>
        /// Gets or sets currency Id.
        /// </summary>
        public int? CurrencyId { get; set; }

        /// <summary>
        /// Gets or sets date of issue.
        /// </summary>
        [DateGreaterOrEqualThan(Constants.DefaultDateTimeString, true)]
        public DateTime? DateOfIssue { get; set; }

        /// <summary>
        /// Gets or sets date of maturity.
        /// </summary>
        [DateGreaterOrEqualThan(Constants.DefaultDateTimeString, true)]
        public DateTime? DateOfMaturity { get; set; }

        /// <summary>
        /// Gets or sets date of payment.
        /// </summary>
        [DateGreaterOrEqualThan(Constants.DefaultDateTimeString, true)]
        public DateTime? DateOfPayment { get; set; }

        /// <summary>
        /// Gets or sets date of taxing.
        /// </summary>
        [DateGreaterOrEqualThan(Constants.DefaultDateTimeString, true)]
        public DateTime? DateOfTaxing { get; set; }

        /// <summary>
        /// Gets or sets date of VAT application.
        /// </summary>
        [DateGreaterOrEqualThan(Constants.DefaultDateTimeString, true)]
        public DateTime? DateOfVatApplication { get; set; }

        /// <summary>
        /// Gets or sets date of VAT claim.
        /// </summary>
        [DateGreaterOrEqualThan(Constants.DefaultDateTimeString, true)]
        public DateTime? DateOfVatClaim { get; set; }

        /// <summary>
        /// Gets or sets delivery address Id.
        /// </summary>
        [NullableForeignKey]
        public NullableProperty<int> DeliveryAddressId { get; set; }

        /// <summary>
        /// Gets or sets description.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets discount.
        /// </summary>
        [Range(0.0, 99.99)]
        public decimal? DiscountPercentage { get; set; }

        /// <summary>
        /// Gets or sets responsibility for handling of electronic records of sales.
        /// </summary>
        public EetResponsibility? EetResponsibility { get; set; }

        /// <summary>
        /// Gets or sets exchange rate.
        /// </summary>
        public decimal? ExchangeRate { get; set; }

        /// <summary>
        /// Gets or sets exchange rate amount.
        /// </summary>
        public decimal? ExchangeRateAmount { get; set; }

        /// <inheritdoc/>
        [Required]
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the document is registered in EET.
        /// </summary>
        public bool? IsEet { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether to include a document to income tax.
        /// </summary>
        public bool? IsIncomeTax { get; set; }

        /// <summary>
        /// Gets or sets items.
        /// </summary>
        public List<CreditNoteItemPatchModel> Items { get; set; }

        /// <summary>
        /// Gets or sets items text prefix.
        /// </summary>
        public string ItemsTextPrefix { get; set; }

        /// <summary>
        /// Gets or sets items text suffix.
        /// </summary>
        public string ItemsTextSuffix { get; set; }

        /// <summary>
        /// Gets or sets my company contact information.
        /// </summary>
        public MyDocumentAddressPatchModel MyAddress { get; set; }

        /// <summary>
        /// Gets or sets your note for the document.
        /// </summary>
        public string Note { get; set; }

        /// <summary>
        /// Gets or sets note for the document.
        /// </summary>
        public string NoteForCreditNote { get; set; }

        /// <summary>
        /// Gets or sets order number.
        /// </summary>
        [StringLength(25)]
        public string OrderNumber { get; set; }

        /// <summary>
        /// Gets or sets contact information of the partner.
        /// </summary>
        public DocumentAddressPatchModel PartnerAddress { get; set; }

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
        /// Gets or sets VAT reverse charge code id.
        /// </summary>
        public int? VatReverseChargeCodeId { get; set; }
    }
}
