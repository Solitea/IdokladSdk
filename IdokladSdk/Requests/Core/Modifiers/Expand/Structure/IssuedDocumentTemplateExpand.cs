using IdokladSdk.Requests.Core.Modifiers.Expand.Common;

namespace IdokladSdk.Requests.Core.Modifiers.Expand.Structure
{
    /// <summary>
    /// IssuedDocumentTemplateExpand.
    /// </summary>
    public class IssuedDocumentTemplateExpand : ExpandableEntity
    {
        /// <summary>
        /// Gets or sets bank account.
        /// </summary>
        public BankAccountExpand BankAccount { get; set; }

        /// <summary>
        /// Gets or sets constantSymbol.
        /// </summary>
        public ConstantSymbolExpand ConstantSymbol { get; set; }

        /// <summary>
        /// Gets or sets currency.
        /// </summary>
        public CurrencyExpand Currency { get; set; }

        /// <summary>
        /// Gets or sets numeric sequence.
        /// </summary>
        public NumericSequenceExpand NumericSequence { get; set; }

        /// <summary>
        /// Gets or sets paymentOption.
        /// </summary>
        public PaymentOptionExpand PaymentOption { get; set; }

        /// <summary>
        /// Gets or sets vatReverseChargeCode.
        /// </summary>
        public VatReverseChargeCodeExpand VatReverseChargeCode { get; set; }

        /// <summary>
        /// Gets or sets items.
        /// </summary>
        public IssuedDocumentTemplateItemExpand Items { get; set; }
    }
}
