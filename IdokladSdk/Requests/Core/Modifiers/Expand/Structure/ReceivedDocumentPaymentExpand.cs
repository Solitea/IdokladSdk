using IdokladSdk.Requests.Core.Modifiers.Expand.Common;

namespace IdokladSdk.Requests.Core.Modifiers.Expand.Structure
{
    /// <summary>
    /// Expand model for ReceivedDocumentPayment.
    /// </summary>
    public class ReceivedDocumentPaymentExpand : ExpandableEntity
    {
        /// <summary>
        /// Gets or sets Currency.
        /// </summary>
        public CurrencyExpand Currency { get; set; }

        /// <summary>
        /// Gets or sets Invoice.
        /// </summary>
        public ReceivedInvoiceExpand Invoice { get; set; }

        /// <summary>
        /// Gets Payment Option.
        /// </summary>
        public PaymentOptionExpand PaymentOption { get; }
    }
}
