using IdokladSdk.Clients;
using IdokladSdk.Enums;
using IdokladSdk.Requests.SalesReceipt.Filter;
using IdokladSdk.Requests.SalesReceipt.Sort;

namespace IdokladSdk.Requests.Report.SalesReceipt
{
    /// <summary>
    /// SalesReceiptReportList.
    /// </summary>
    public class SalesReceiptReportList : BaseReportList<SalesReceiptReportList, ReportClient, string, SalesReceiptFilter, SalesReceiptSort>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SalesReceiptReportList"/> class.
        /// </summary>
        /// <param name="client">Client.</param>
        public SalesReceiptReportList(ReportClient client)
            : base(client, ReportDocumentType.SalesReceipt)
        {
        }
    }
}
