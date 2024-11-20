using IdokladSdk.Models.ReadOnly.Currency;
using IdokladSdk.Models.ReceivedInvoice;

namespace IdokladSdk.Models.Payment.DocumentPayments.Purchases.Detail
{
    /// <summary>
    /// PurchaseDocumentPaymentForReceivedReceiptGetModel.
    /// </summary>
    public class PurchaseDocumentPaymentForReceivedReceiptGetModel : PaymentBaseGetModel
    {
        /// <summary>
        /// Gets or sets currency.
        /// </summary>
        public CurrencyGetModel Currency { get; set; }

        /// <summary>
        /// Gets or sets received invoice.
        /// </summary>
        public ReceivedInvoiceGetModel ReceivedInvoice { get; set; }

        /// <summary>
        /// Gets or sets received invoice id.
        /// </summary>
        public int ReceivedInvoiceId { get; set; }
    }
}
