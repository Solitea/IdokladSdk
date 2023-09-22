using IdokladSdk.Requests.DocumentPayment.Sales;

namespace IdokladSdk.Clients
{
    /// <summary>
    /// DocumentPaymentClient.
    /// </summary>
    public class DocumentPaymentClient : BaseClient
    {
        private SalesDocumentPayment _sales;

        /// <summary>
        /// Initializes a new instance of the <see cref="DocumentPaymentClient" /> class.
        /// </summary>
        /// <param name="apiContext">Api context.</param>
        public DocumentPaymentClient(ApiContext apiContext)
            : base(apiContext)
        {
        }

        /// <inheritdoc />
        public override string ResourceUrl { get; } = "/DocumentPayments";

        /// <summary>
        /// Gets sales.
        /// </summary>
        public SalesDocumentPayment Sales => _sales ?? (_sales = new SalesDocumentPayment(this));
    }
}
