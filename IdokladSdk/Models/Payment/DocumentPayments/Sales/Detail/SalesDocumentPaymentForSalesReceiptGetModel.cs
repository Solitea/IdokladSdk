using IdokladSdk.Models.ReadOnly.Currency;
using IdokladSdk.Models.SalesReceipt;

namespace IdokladSdk.Models.Payment.DocumentPayments.Sales.Detail
{
    /// <summary>
    /// SalesDocumentPaymentForSalesReceiptGetModel.
    /// </summary>
    public class SalesDocumentPaymentForSalesReceiptGetModel : PaymentBaseGetModel
    {
        /// <summary>
        /// Gets or sets currency.
        /// </summary>
        public CurrencyGetModel Currency { get; set; }

        /// <summary>
        /// Gets or sets sales receipt.
        /// </summary>
        public SalesReceiptGetModel SalesReceipt { get; set; }

        /// <summary>
        /// Gets or sets sales receipt id.
        /// </summary>
        public int SalesReceiptId { get; set; }
    }
}
