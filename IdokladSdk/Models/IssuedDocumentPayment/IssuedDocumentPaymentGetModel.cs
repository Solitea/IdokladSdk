using IdokladSdk.Models.IssuedInvoice;
using IdokladSdk.Models.ReadOnly.Currency;
using IdokladSdk.Models.ReadOnly.PaymentOption;

namespace IdokladSdk.Models.IssuedDocumentPayment
{
    /// <summary>
    /// Model for Get endpoints.
    /// </summary>
    public class IssuedDocumentPaymentGetModel : IssuedDocumentPaymentListGetModel
    {
        /// <summary>
        /// Gets or sets currency.
        /// </summary>
        public CurrencyGetModel Currency { get; set; }

        /// <summary>
        /// Gets or sets invoice.
        /// </summary>
        public IssuedInvoiceGetModel Invoice { get; set; }

        /// <summary>
        /// Gets or sets payment option.
        /// </summary>
        public PaymentOptionGetModel PaymentOption { get; set; }
    }
}
