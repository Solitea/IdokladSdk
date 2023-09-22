namespace IdokladSdk.Requests.Core.Modifiers.Expand.Structure
{
    /// <summary>
    /// Expand model for sales receipt.
    /// </summary>
    public class SalesDocumentPaymentForSalesReceiptExpand
    {
        /// <summary>
        /// Gets or sets bank currency.
        /// </summary>
        public CurrencyExpand Currency { get; set; }

        /// <summary>
        /// Gets or sets sales receipt.
        /// </summary>
        public SalesReceiptExpand SalesReceipt { get; set; }
    }
}
