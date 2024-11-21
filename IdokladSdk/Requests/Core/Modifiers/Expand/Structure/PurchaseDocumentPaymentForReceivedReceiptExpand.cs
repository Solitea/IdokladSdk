namespace IdokladSdk.Requests.Core.Modifiers.Expand.Structure
{
    /// <summary>
    /// PurchaseDocumentPaymentForReceivedReceiptExpand.
    /// </summary>
    public class PurchaseDocumentPaymentForReceivedReceiptExpand
    {
        /// <summary>
        /// Gets or sets currency.
        /// </summary>
        public CurrencyExpand Currency { get; set; }

        /// <summary>
        /// Gets or sets received invoice.
        /// </summary>
        public ReceivedInvoiceExpand ReceivedInvoice { get; set; }
    }
}
