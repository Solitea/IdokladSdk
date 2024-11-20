using IdokladSdk.Clients;
using IdokladSdk.Clients.Interfaces;

namespace IdokladSdk.Requests.DocumentPayment.Purchases
{
    /// <summary>
    /// PurchasesDocumentPayment.
    /// </summary>
    public class PurchasesDocumentPayment : IEntityList<PurchasesDocumentPaymentList>
    {
        private readonly DocumentPaymentClient _client;

        /// <summary>
        /// Initializes a new instance of the <see cref="PurchasesDocumentPayment" /> class.
        /// </summary>
        /// <param name="client">Client.</param>
        public PurchasesDocumentPayment(DocumentPaymentClient client)
        {
            _client = client;
        }

        /// <summary>
        /// Returns information about a payment.
        /// </summary>
        /// <param name="id">Payment id.</param>
        /// <returns>Payment of issued invoice with information.</returns>
        public ReceivedInvoicePaymentDetail GetReceivedInvoicePayment(int id)
        {
            return new ReceivedInvoicePaymentDetail(id, _client);
        }

        /// <summary>
        /// Returns information about a payment.
        /// </summary>
        /// <param name="id">Payment id.</param>
        /// <returns>Payment of issued invoice with information.</returns>
        public ReceivedReceiptPaymentDetail GetReceivedReceiptPayment(int id)
        {
            return new ReceivedReceiptPaymentDetail(id, _client);
        }

        /// <inheritdoc />
        public PurchasesDocumentPaymentList List()
        {
            return new PurchasesDocumentPaymentList(_client);
        }
    }
}
