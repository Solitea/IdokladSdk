using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using IdokladSdk.Enums;
using IdokladSdk.Validation.Attributes;

namespace IdokladSdk.Models.ProformaInvoice
{
    /// <summary>
    /// ProformaInvoicePatchModel.
    /// </summary>
    public class ProformaInvoicePatchModel : IEntityId
    {
        /// <inheritdoc/>
        [RequiredNonDefault]
        public int Id { get; set; }

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
        public DateTime? DateOfIssue { get; set; }

        /// <summary>
        /// Gets or sets date of maturity.
        /// </summary>
        public DateTime? DateOfMaturity { get; set; }

        /// <summary>
        /// Gets or sets date of payment.
        /// </summary>
        public DateTime? DateOfPayment { get; set; }

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
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets responsibility for handlig of electronic records of sales.
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

        /// <summary>
        /// Gets or sets flag indicating whether the document is registered in EET.
        /// </summary>
        public bool? IsEet { get; set; }

        /// <summary>
        /// Gets or sets zahrnout doklad do daňového přiznání.
        /// </summary>
        /// <summary xml:lang='en'>
        /// Include subject to income tax.
        /// </summary>
        public bool? IsIncomeTax { get; set; }

        /// <summary>
        /// Gets or sets is proforma a tax movement indication.
        /// </summary>
        public bool? IsProformaTaxed { get; set; }

        /// <summary>
        /// Gets or sets invoice items.
        /// </summary>
        public List<ProformaInvoiceItemPatchModel> Items { get; set; }

        /// <summary>
        /// Gets or sets text za položkami.
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
        /// Gets or sets order number.
        /// </summary>
        [StringLength(20)]
        public string OrderNumber { get; set; }

        /// <summary>
        /// Gets or sets contact information of the partner.
        /// </summary>
        public DocumentAddress.DocumentAddressPatchModel PartnerAddress { get; set; }

        /// <summary>
        /// Gets or sets payment option id.
        /// </summary>
        [NullableForeignKey]
        public int? PaymentOptionId { get; set; }

        /// <summary>
        /// Gets or sets partner contact id.
        /// </summary>
        [NullableForeignKey]
        public int? PartnerId { get; set; }

        /// <summary>
        /// Gets or sets report language.
        /// </summary>
        public Language? ReportLanguage { get; set; }

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
        public int? VatReverseChargeCodeId { get; set; }
    }
}
