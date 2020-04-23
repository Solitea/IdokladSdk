using IdokladSdk.Requests.Mail;

namespace IdokladSdk.Clients
{
    /// <summary>
    /// Client for communication with mail endpoints.
    /// </summary>
    public partial class MailClient : BaseClient
    {
        private CreditNoteEmail _creditNoteEmail;
        private IssuedInvoiceEmail _issuedInvoiceEmail;
        private IssuedDocumentPaymentConfirmationEmail _issuedDocumentPaymentConfirmationEmail;
        private ProformaInvoiceEmail _proformaInvoiceEmail;
        private ReceivedInvoiceEmail _receivedInvoiceEmail;
        private RemindersEmail _remindersEmail;
        private SalesOrderEmail _salesOrderEmail;

        /// <summary>
        /// Initializes a new instance of the <see cref="MailClient"/> class.
        /// </summary>
        /// <param name="context">API context.</param>
        public MailClient(ApiContext context)
            : base(context)
        {
        }

        /// <inheritdoc/>
        public override string ResourceUrl => "/Mails";

        /// <summary>
        /// Gets credit note email.
        /// </summary>
        public CreditNoteEmail CreditNoteEmail => _creditNoteEmail ?? (_creditNoteEmail = new CreditNoteEmail(this));

        /// <summary>
        /// Gets issued invoice email.
        /// </summary>
        public IssuedInvoiceEmail IssuedInvoiceEmail => _issuedInvoiceEmail ?? (_issuedInvoiceEmail = new IssuedInvoiceEmail(this));

        /// <summary>
        /// Gets issued document payments confirmation email.
        /// </summary>
        public IssuedDocumentPaymentConfirmationEmail IssuedDocumentPaymentConfirmationEmail =>
            _issuedDocumentPaymentConfirmationEmail ?? (_issuedDocumentPaymentConfirmationEmail = new IssuedDocumentPaymentConfirmationEmail(this));

        /// <summary>
        /// Gets proforma invoice email.
        /// </summary>
        public ProformaInvoiceEmail ProformaInvoiceEmail => _proformaInvoiceEmail ?? (_proformaInvoiceEmail = new ProformaInvoiceEmail(this));

        /// <summary>
        /// Gets received invoice email.
        /// </summary>
        public ReceivedInvoiceEmail ReceivedInvoiceEmail => _receivedInvoiceEmail ?? (_receivedInvoiceEmail = new ReceivedInvoiceEmail(this));

        /// <summary>
        /// Gets remainders email.
        /// </summary>
        public RemindersEmail RemindersEmail => _remindersEmail ?? (_remindersEmail = new RemindersEmail(this));

        /// <summary>
        /// Gets sales order email.
        /// </summary>
        public SalesOrderEmail SalesOrderEmail => _salesOrderEmail ?? (_salesOrderEmail = new SalesOrderEmail(this));
    }
}
