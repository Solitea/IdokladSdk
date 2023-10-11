using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using IdokladSdk.Enums;
using IdokladSdk.Models.Base;
using IdokladSdk.Models.Common;
using IdokladSdk.Models.DocumentAddress;
using IdokladSdk.Validation.Attributes;

namespace IdokladSdk.Models.IssuedInvoice
{
    /// <summary>
    /// IssuedInvoicePatchModel.
    /// </summary>
    public class IssuedInvoicePatchModel : ValidatableModel, IEntityId
    {
        /// <summary>
        /// Gets or sets constant symbol Id.
        /// </summary>
        [NullableForeignKey]
        public int? ConstantSymbolId { get; set; }

        /// <summary>
        /// Gets or sets currency Id.
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
        /// Gets or sets delivery address Id.
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
        [Range(0.0, 100)]
        public decimal? DiscountPercentage { get; set; }

        /// <summary>
        /// Gets or sets responsibility for handlig of electronic records of sales..
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
        [RequiredNonDefault]
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets flag indicating whether the document is registered in EET.
        /// </summary>
        public bool? IsEet { get; set; }

        /// <summary>
        /// Gets or sets flag indicating whether the document is subject to income tax.
        /// </summary>
        public bool? IsIncomeTax { get; set; }

        /// <summary>
        /// Gets or sets invoice items.
        /// </summary>
        public List<IssuedInvoiceItemPatchModel> Items { get; set; }

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
        /// Gets or sets note.
        /// </summary>
        public string Note { get; set; }

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
        [NullableForeignKey]
        public int? PartnerId { get; set; }

        /// <summary>
        /// Gets or sets payment option id.
        /// </summary>
        [NullableForeignKey]
        public int? PaymentOptionId { get; set; }

        /// <summary>
        /// Gets or sets report language.
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
        /// Gets or sets vAT reverse charge code id.
        /// </summary>
        [NullableForeignKey]
        public NullableProperty<int> VatReverseChargeCodeId { get; set; }
    }
}
