using IdokladSdk.Clients;
using IdokladSdk.Enums;

namespace IdokladSdk.Requests.Report.IssuedInvoice
{
    /// <summary>
    /// IssuedInvoiceReport.
    /// </summary>
    public class IssuedInvoiceReport
    {
        private readonly ReportClient _client;
        private readonly ReportDocumentType _documentType;

        /// <summary>
        /// Initializes a new instance of the <see cref="IssuedInvoiceReport"/> class.
        /// </summary>
        /// <param name="client">Client.</param>
        /// <param name="documentType">Document type.</param>
        public IssuedInvoiceReport(ReportClient client, ReportDocumentType documentType)
        {
            _client = client;
            _documentType = documentType;
        }

        /// <summary>
        /// Detail.
        /// </summary>
        /// <param name="id">Id.</param>
        /// <returns>Detail of issued invoice report.</returns>
        public IssuedInvoiceDetailReport Detail(int id)
        {
            return new IssuedInvoiceDetailReport(id, _client, _documentType);
        }

        /// <summary>
        /// List.
        /// </summary>
        /// <returns>Return list.</returns>
        public IssuedInvoiceReportList List()
        {
            return new IssuedInvoiceReportList(_client, _documentType);
        }
    }
}
