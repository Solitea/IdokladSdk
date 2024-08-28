using IdokladSdk.Clients;
using IdokladSdk.Enums;

namespace IdokladSdk.Requests.Report.BankStatement
{
    /// <summary>
    /// BankStatementReport.
    /// </summary>
    public class BankStatementReport : Report
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BankStatementReport"/> class.
        /// </summary>
        /// <param name="client">Client.</param>
        public BankStatementReport(ReportClient client)
            : base(client, ReportDocumentType.BankStatement)
        {
        }

        /// <summary>
        /// List.
        /// </summary>
        /// <returns>Returns list.</returns>
        public BankStatementReportList List()
        {
            return new BankStatementReportList(Client);
        }
    }
}
