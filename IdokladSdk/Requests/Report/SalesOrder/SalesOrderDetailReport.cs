using IdokladSdk.Clients;
using IdokladSdk.Enums;

namespace IdokladSdk.Requests.Report.SalesOrder
{
    /// <summary>
    /// SalesOrderDetailReport.
    /// </summary>
    public class SalesOrderDetailReport : ReportBaseDetail
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SalesOrderDetailReport"/> class.
        /// </summary>
        /// <param name="id">Id.</param>
        /// <param name="client">Report client.</param>
        public SalesOrderDetailReport(int id, ReportClient client)
            : base(id, client, ReportDocumentType.SalesOrder)
        {
        }
    }
}
