using System.Collections.Generic;
using IdokladSdk.Enums;
using IdokladSdk.Models.Base;
using IdokladSdk.Models.Common;
using IdokladSdk.Validation.Attributes;

namespace IdokladSdk.Models.RecurringInvoice
{
    /// <summary>
    /// InvoiceTemplatePatchModel.
    /// </summary>
    public class InvoiceTemplatePatchModel : ValidatableModel
    {
        /// <summary>
        /// Gets or sets bank account Id.
        /// </summary>
        [NullableForeignKey]
        public int? BankAccountId { get; set; }

        /// <summary>
        /// Gets or sets constant symbol Id.
        /// </summary>
        [NullableForeignKey]
        public NullableProperty<int> ConstantSymbolId { get; set; }

        /// <summary>
        /// Gets or sets delivery address Id.
        /// </summary>
        [NullableForeignKey]
        public NullableProperty<int> DeliveryAddressId { get; set; }

        /// <summary>
        /// Gets or sets currency Id.
        /// </summary>
        [NullableForeignKey]
        public int? CurrencyId { get; set; }

        /// <summary>
        /// Gets or sets description.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets discount size in percent.
        /// </summary>
        public decimal? DiscountPercentage { get; set; }

        /// <summary>
        /// Gets or sets document type.
        /// </summary>
        public RecurringDocumentType? DocumentType { get; set; }

        /// <summary>
        /// Gets or sets invoice maturity (in days).
        /// </summary>
        public int? InvoiceMaturity { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether fixed variable symbol is used.
        /// </summary>
        public bool? IsConstantVariableSymbol { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether application of VAT is based on payments.
        /// </summary>
        public bool? IsDocumentInVatOnPay { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the document is registered in EET.
        /// </summary>
        public bool? IsEet { get; set; }

        /// <summary>
        /// Gets or sets invoice items.
        /// </summary>
        public List<InvoiceItemTemplatePatchModel> Items { get; set; }

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
        [NullableForeignKey]
        public int? NumericSequenceId { get; set; }

        /// <summary>
        /// Gets or sets order number.
        /// </summary>
        public string OrderNumber { get; set; }

        /// <summary>
        /// Gets or sets partner contact Id.
        /// </summary>
        [NullableForeignKey]
        public int? PartnerId { get; set; }

        /// <summary>
        /// Gets or sets payment option Id.
        /// </summary>
        [NullableForeignKey]
        public int? PaymentOptionId { get; set; }

        /// <summary>
        /// Gets or sets report language.
        /// </summary>
        public Language? ReportLanguage { get; set; }

        /// <summary>
        /// Gets or sets setting for date of taxing.
        /// </summary>
        public TaxingType? TaxingType { get; set; }

        /// <summary>
        /// Gets or sets variable symbol.
        /// </summary>
        [RequiredIf(nameof(IsConstantVariableSymbol), true)]
        public string VariableSymbol { get; set; }

        /// <summary>
        /// Gets or sets VAT reverse charge code Id.
        /// </summary>
        [NullableForeignKey]
        public NullableProperty<int> VatReverseChargeCodeId { get; set; }
    }
}
