using IdokladSdk.Clients;
using IdokladSdk.Clients.Interfaces;

namespace IdokladSdk.Requests.DocumentPayment.Sales
{
    /// <summary>
    /// SalesDocumentPayment.
    /// </summary>
    public class SalesDocumentPayment : IEntityList<SalesDocumentPaymentList>
    {
        private readonly DocumentPaymentClient _client;

        /// <summary>
        /// Initializes a new instance of the <see cref="SalesDocumentPayment" /> class.
        /// </summary>
        /// <param name="client">Client.</param>
        public SalesDocumentPayment(DocumentPaymentClient client)
        {
            _client = client;
        }

        /// <summary>
        /// Returns information about a payment.
        /// </summary>
        /// <param name="id">Payment id.</param>
        /// <returns>Payment of credit note with information.</returns>
        public CreditNotePaymentDetail GetCreditNotePayment(int id)
        {
            return new CreditNotePaymentDetail(id, _client);
        }

        /// <summary>
        /// Returns information about a payment.
        /// </summary>
        /// <param name="id">Payment id.</param>
        /// <returns>Payment of issued invoice with information.</returns>
        public IssuedInvoicePaymentDetail GetIssuedInvoicePayment(int id)
        {
            return new IssuedInvoicePaymentDetail(id, _client);
        }

        /// <summary>
        /// Returns information about a payment.
        /// </summary>
        /// <param name="id">Payment id.</param>
        /// <returns>Payment of proforma invoice with information.</returns>
        public ProformaInvoicePaymentDetail GetProformaInvoicePayment(int id)
        {
            return new ProformaInvoicePaymentDetail(id, _client);
        }

        /// <summary>
        /// Returns information about a payment.
        /// </summary>
        /// <param name="id">Payment id.</param>
        /// <returns>Payment of sales receipt with information.</returns>
        public SalesReceiptPaymentDetail GetSalesReceiptPayment(int id)
        {
            return new SalesReceiptPaymentDetail(id, _client);
        }

        /// <inheritdoc />
        public SalesDocumentPaymentList List()
        {
            return new SalesDocumentPaymentList(_client);
        }
    }
}
