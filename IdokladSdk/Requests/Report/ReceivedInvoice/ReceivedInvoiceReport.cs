using IdokladSdk.Clients;
using IdokladSdk.Enums;

namespace IdokladSdk.Requests.Report.ReceivedInvoice
{
    /// <summary>
    /// ReceivedInvoiceReport.
    /// </summary>
    public class ReceivedInvoiceReport : Report
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ReceivedInvoiceReport"/> class.
        /// </summary>
        /// <param name="client">Client.</param>
        public ReceivedInvoiceReport(ReportClient client)
            : base(client, ReportDocumentType.ReceivedInvoice)
        {
        }

        /// <summary>
        /// List.
        /// </summary>
        /// <returns>Return list.</returns>
        public ReceivedInvoiceReportList List()
        {
            return new ReceivedInvoiceReportList(Client);
        }
    }
}
