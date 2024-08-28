using IdokladSdk.Clients;
using IdokladSdk.Enums;
using IdokladSdk.Requests.BankStatement.Filter;
using IdokladSdk.Requests.Core.Modifiers.Sort.BasicSorts;

namespace IdokladSdk.Requests.Report.BankStatement
{
    /// <summary>
    /// BankStatementReportList.
    /// </summary>
    public class BankStatementReportList : BaseReportList<BankStatementReportList, ReportClient, string, BankStatementFilter, IdSort>
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
