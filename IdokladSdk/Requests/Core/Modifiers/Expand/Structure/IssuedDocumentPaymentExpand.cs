using IdokladSdk.Requests.Core.Modifiers.Expand.Common;

namespace IdokladSdk.Requests.Core.Modifiers.Expand.Structure
{
    /// <summary>
    /// Expand model for Issued Document Payment.
    /// </summary>
    public class IssuedDocumentPaymentExpand : ExpandableEntity
    {
        /// <summary>
        /// Gets Cash Voucher.
        /// </summary>
        public CurrencyExpand Currency { get; }

        /// <summary>
        /// Gets Invoice.
        /// </summary>
        public IssuedInvoiceExpand Invoice { get; }

        /// <summary>
        /// Gets Payment Option.
        /// </summary>
        public PaymentOptionExpand PaymentOption { get; }
    }
}
