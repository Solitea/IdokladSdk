using IdokladSdk.Enums;
using IdokladSdk.Requests.Report.CashVoucher;
using IdokladSdk.Requests.Report.IssuedInvoice;
using IdokladSdk.Requests.Report.IssuedTaxDocument;
using IdokladSdk.Requests.Report.ReceivedInvoice;
using IdokladSdk.Requests.Report.SalesOrder;
using IdokladSdk.Requests.Report.SalesReceipt;

namespace IdokladSdk.Clients
{
    /// <summary>
    /// Client for communication with report endpoints.
    /// </summary>
    public class ReportClient : BaseClient
    {
        private CashVoucherReport _cashVoucher;
        private IssuedInvoiceReport _creditNote;
        private IssuedInvoiceReport _issuedInvoice;
        private IssuedTaxDocumentReport _issuedTaxDocument;
        private IssuedInvoiceReport _proformaInvoice;
        private ReceivedInvoiceReport _receivedInvoice;
        private SalesOrderReport _salesOrder;
        private SalesReceiptReport _salesReceipt;

        /// <summary>
        /// Initializes a new instance of the <see cref="ReportClient" /> class.
        /// </summary>
        /// <param name="apiContext">API context.</param>
        public ReportClient(ApiContext apiContext)
            : base(apiContext)
        {
        }

        /// <summary>
        /// Gets cash voucher reports.
        /// </summary>
        public CashVoucherReport CashVoucher => _cashVoucher ?? (_cashVoucher = new CashVoucherReport(this));

        /// <summary>
        /// Gets credit note reports.
        /// </summary>
        public IssuedInvoiceReport CreditNote => _creditNote ?? (_creditNote = new IssuedInvoiceReport(this, ReportDocumentType.CreditNote));

        /// <summary>
        /// Gets issued invoice reports.
        /// </summary>
        public IssuedInvoiceReport IssuedInvoice => _issuedInvoice ?? (_issuedInvoice = new IssuedInvoiceReport(this, ReportDocumentType.IssuedInvoice));

        /// <summary>
        /// Gets issued tax document reports.
        /// </summary>
        public IssuedTaxDocumentReport IssuedTaxDocument => _issuedTaxDocument ?? (_issuedTaxDocument = new IssuedTaxDocumentReport(this));

        /// <summary>
        /// Gets proforma invoice reports.
        /// </summary>
        public IssuedInvoiceReport ProformaInvoice => _proformaInvoice ?? (_proformaInvoice = new IssuedInvoiceReport(this, ReportDocumentType.ProformaInvoice));

        /// <summary>
        /// Gets received invoice reports.
        /// </summary>
        public ReceivedInvoiceReport ReceivedInvoice => _receivedInvoice ?? (_receivedInvoice = new ReceivedInvoiceReport(this));

        /// <inheritdoc />
        public override string ResourceUrl { get; } = "/Reports/";

        /// <summary>
        /// Gets sales order reports.
        /// </summary>
        public SalesOrderReport SalesOrder => _salesOrder ?? (_salesOrder = new SalesOrderReport(this));

        /// <summary>
        /// Gets sales receipt reports.
        /// </summary>
        public SalesReceiptReport SalesReceipt => _salesReceipt ?? (_salesReceipt = new SalesReceiptReport(this));
    }
}
