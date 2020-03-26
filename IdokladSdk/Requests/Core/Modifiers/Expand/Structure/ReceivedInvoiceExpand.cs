using IdokladSdk.Requests.Core.Modifiers.Expand.Common;

namespace IdokladSdk.Requests.Core.Modifiers.Expand.Structure
{
    /// <summary>
    /// ReceivedInvoiceExpand.
    /// </summary>
    public class ReceivedInvoiceExpand : ExpandableEntity
    {
        /// <summary>
        /// Gets or sets items.
        /// </summary>
        public ReceivedInvoiceItemExpand Items { get; set; }

        /// <summary>
        /// Gets or sets partner.
        /// </summary>
        public ContactExpand Partner { get; set; }

        /// <summary>
        /// Gets or sets currency.
        /// </summary>
        public CurrencyExpand Currency { get; set; }

        /// <summary>
        /// Gets or sets payment option.
        /// </summary>
        public PaymentOptionExpand PaymentOption { get; set; }

        /// <summary>
        /// Gets or sets vat reverse charge code.
        /// </summary>
        public VatReverseChargeCodeExpand VatReverseChargeCode { get; set; }
    }
}
