using IdokladSdk.Clients;

namespace IdokladSdk.Requests.Report.IssuedTaxDocument
{
    /// <summary>
    /// IssuedTaxDocumentReport.
    /// </summary>
    public class IssuedTaxDocumentReport : Report
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="IssuedTaxDocumentReport"/> class.
        /// </summary>
        /// <param name="client">Client.</param>
        public IssuedTaxDocumentReport(ReportClient client)
            : base(client, Enums.ReportDocumentType.IssuedTaxDocument)
        {
        }
    }
}
