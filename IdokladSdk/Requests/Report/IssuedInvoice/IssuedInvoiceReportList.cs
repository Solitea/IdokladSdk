using IdokladSdk.Clients;
using IdokladSdk.Enums;
using IdokladSdk.Requests.IssuedInvoice.Filter;
using IdokladSdk.Requests.IssuedInvoice.Sort;

namespace IdokladSdk.Requests.Report.IssuedInvoice
{
    /// <summary>
    /// IssuedInvoiceReportList.
    /// </summary>
    public class IssuedInvoiceReportList : BaseReportList<IssuedInvoiceReportList, ReportClient, string, IssuedInvoiceFilter, IssuedInvoiceSort>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="IssuedInvoiceReportList"/> class.
        /// </summary>
        /// <param name="client">Client.</param>
        /// <param name="documentType">Document type.</param>
        public IssuedInvoiceReportList(ReportClient client, ReportDocumentType documentType)
            : base(client, documentType)
        {
        }
    }
}
