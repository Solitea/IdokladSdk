using IdokladSdk.Clients;
using IdokladSdk.Enums;
using IdokladSdk.Requests.ReceivedInvoice.Filter;
using IdokladSdk.Requests.ReceivedInvoice.Sort;

namespace IdokladSdk.Requests.Report.ReceivedInvoice
{
    /// <summary>
    /// ReceivedInvoiceReportList.
    /// </summary>
    public class ReceivedInvoiceReportList : BaseReportList<ReceivedInvoiceReportList, ReportClient, string, ReceivedInvoiceFilter, ReceivedInvoiceSort>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ReceivedInvoiceReportList"/> class.
        /// </summary>
        /// <param name="client">Client.</param>
        public ReceivedInvoiceReportList(ReportClient client)
            : base(client, ReportDocumentType.ReceivedInvoice)
        {
        }
    }
}
