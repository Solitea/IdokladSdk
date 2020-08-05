using IdokladSdk.Clients;
using IdokladSdk.Enums;

namespace IdokladSdk.Requests.Report.SalesOrder
{
    /// <summary>
    /// SalesOrderReport.
    /// </summary>
    public class SalesOrderReport : Report
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SalesOrderReport"/> class.
        /// </summary>
        /// <param name="client">Client.</param>
        public SalesOrderReport(ReportClient client)
            : base(client, ReportDocumentType.SalesOrder)
        {
        }
    }
}
