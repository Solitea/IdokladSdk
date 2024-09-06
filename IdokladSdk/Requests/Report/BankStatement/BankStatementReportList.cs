using IdokladSdk.Clients;
using IdokladSdk.Enums;
using IdokladSdk.Requests.Report.BankStatement.Filter;
using IdokladSdk.Requests.Report.BankStatement.Sort;

namespace IdokladSdk.Requests.Report.BankStatement
{
    /// <summary>
    /// BankStatementReportList.
    /// </summary>
    public class BankStatementReportList : BaseReportList<BankStatementReportList, ReportClient, string, BankStatementReportFilter, BankStatementReportSort>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BankStatementReportList"/> class.
        /// </summary>
        /// <param name="client">Client.</param>
        public BankStatementReportList(ReportClient client)
            : base(client, ReportDocumentType.BankStatement)
        {
        }
    }
}
