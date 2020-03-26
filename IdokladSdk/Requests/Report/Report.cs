using IdokladSdk.Clients;
using IdokladSdk.Enums;

namespace IdokladSdk.Requests.Report
{
    /// <summary>
    /// Report.
    /// </summary>
    public class Report
    {
        private readonly ReportDocumentType _documentType;

        /// <summary>
        /// Initializes a new instance of the <see cref="Report"/> class.
        /// </summary>
        /// <param name="client">Client.</param>
        /// <param name="documentType">Document type.</param>
        public Report(ReportClient client, ReportDocumentType documentType)
        {
            Client = client;
            _documentType = documentType;
        }

        /// <summary>
        /// Gets client.
        /// </summary>
        protected ReportClient Client { get; }

        /// <summary>
        /// Detail.
        /// </summary>
        /// <param name="id">Id.</param>
        /// <returns>Detail of issued invoice report.</returns>
        public ReportDetail Detail(int id)
        {
            return new ReportDetail(id, Client, _documentType);
        }
    }
}
