using IdokladSdk.Clients;
using IdokladSdk.Enums;

namespace IdokladSdk.Requests.Report.SalesReceipt
{
    /// <summary>
    /// SalesReceiptReport.
    /// </summary>
    public class SalesReceiptReport : Report
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SalesReceiptReport"/> class.
        /// </summary>
        /// <param name="client">Client.</param>
        public SalesReceiptReport(ReportClient client)
            : base(client, ReportDocumentType.SalesReceipt)
        {
        }

        /// <summary>
        /// List.
        /// </summary>
        /// <returns>Return list.</returns>
        public SalesReceiptReportList List()
        {
            return new SalesReceiptReportList(Client);
        }
    }
}
