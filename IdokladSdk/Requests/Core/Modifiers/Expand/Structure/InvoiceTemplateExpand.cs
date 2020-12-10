namespace IdokladSdk.Requests.Core.Modifiers.Expand.Structure
{
    public class InvoiceTemplateExpand
    {
        /// <summary>
        /// Gets or sets constantSymbol.
        /// </summary>
        public ConstantSymbolExpand ConstantSymbol { get; set; }

        /// <summary>
        /// Gets or sets currency.
        /// </summary>
        public CurrencyExpand Currency { get; set; }

        /// <summary>
        /// Gets or sets items.
        /// </summary>
        public InvoiceTemplateItemExpand Items { get; set; }

        /// <summary>
        /// Gets or sets partner.
        /// </summary>
        public ContactExpand Partner { get; set; }

        /// <summary>
        /// Gets or sets paymentOption.
        /// </summary>
        public PaymentOptionExpand PaymentOption { get; set; }

        /// <summary>
        /// Gets or sets vatReverseChargeCode.
        /// </summary>
        public VatReverseChargeCodeExpand VatReverseChargeCode { get; set; }
    }
}
