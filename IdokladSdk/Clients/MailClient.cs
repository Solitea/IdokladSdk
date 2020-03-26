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
        private ProformaInvoiceEmail _proformaInvoiceEmail;
        private ReceivedInvoiceEmail _receivedInvoiceEmail;
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
        /// Gets proforma invoice email.
        /// </summary>
        public ProformaInvoiceEmail ProformaInvoiceEmail => _proformaInvoiceEmail ?? (_proformaInvoiceEmail = new ProformaInvoiceEmail(this));

        /// <summary>
        /// Gets received invoice email.
        /// </summary>
        public ReceivedInvoiceEmail ReceivedInvoiceEmail => _receivedInvoiceEmail ?? (_receivedInvoiceEmail = new ReceivedInvoiceEmail(this));

        /// <summary>
        /// Gets sales order email.
        /// </summary>
        public SalesOrderEmail SalesOrderEmail => _salesOrderEmail ?? (_salesOrderEmail = new SalesOrderEmail(this));
    }
}
