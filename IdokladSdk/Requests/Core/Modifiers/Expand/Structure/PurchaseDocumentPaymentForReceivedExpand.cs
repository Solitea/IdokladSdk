namespace IdokladSdk.Requests.Core.Modifiers.Expand.Structure
{
    /// <summary>
    /// PurchaseDocumentPaymentForReceivedExpand.
    /// </summary>
    public class PurchaseDocumentPaymentForReceivedExpand
    {
        /// <summary>
        /// Gets or sets bank statement.
        /// </summary>
        public BankStatementExpand BankStatement { get; set; }

        /// <summary>
        /// Gets or sets cash voucher.
        /// </summary>
        public CashVoucherExpand CashVoucher { get; set; }

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
