using IdokladSdk.Models.BankStatement;
using IdokladSdk.Requests.Core.Modifiers.Sort.BasicSorts;
using IdokladSdk.Requests.Core.Modifiers.Sort.Common;

namespace IdokladSdk.Requests.Report.BankStatement.Sort
{
    /// <summary>
    /// Sort for bank statement report list.
    /// </summary>
    public class BankStatementReportSort : IdSort
    {
        /// <inheritdoc cref="BankStatementListGetModel.DateOfTransaction"/>
        public SortItem DateOfTransaction { get; set; } = new SortItem(nameof(BankStatementListGetModel.DateOfTransaction));
    }
}
