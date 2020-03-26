using IdokladSdk.Models.ReadOnly.Currency;
using IdokladSdk.Models.ReadOnly.PaymentOption;
using IdokladSdk.Models.ReceivedInvoice;

namespace IdokladSdk.Models.ReceivedDocumentPayments
{
    /// <summary>
    /// GET model of ReceivedDocumentPayment.
    /// </summary>
    public class ReceivedDocumentPaymentGetModel : ReceivedDocumentPaymentListGetModel
    {
        /// <summary>
        /// Gets or sets currency.
        /// </summary>
        public CurrencyGetModel Currency { get; set; }

        /// <summary>
        /// Gets or sets invoice.
        /// </summary>
        public ReceivedInvoiceGetModel Invoice { get; set; }

        /// <summary>
        /// Gets or sets payment option.
        /// </summary>
        public PaymentOptionGetModel PaymentOption { get; set; }
    }
}
