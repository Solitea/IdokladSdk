using IdokladSdk.Requests.Core.Modifiers.Expand.Common;

namespace IdokladSdk.Requests.Core.Modifiers.Expand.Structure
{
    /// <summary>
    /// Expand model for SalesReceiptPayment.
    /// </summary>
    public class SalesReceiptPaymentExpand : ExpandableEntity
    {
        /// <summary>
        /// Gets paymentOption.
        /// </summary>
        public PaymentOptionExpand PaymentOption { get; }
    }
}
