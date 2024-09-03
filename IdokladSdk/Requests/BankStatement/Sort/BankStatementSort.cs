using IdokladSdk.Models.BankStatement;
using IdokladSdk.Requests.Core.Modifiers.Sort.BasicSorts;
using IdokladSdk.Requests.Core.Modifiers.Sort.Common;

namespace IdokladSdk.Requests.BankStatement.Sort
{
    /// <summary>
    /// Sortable properties of <see cref="BankStatementListGetModel"/>.
    /// </summary>
    public class BankStatementSort : IdSort
    {
        /// <inheritdoc cref="BankStatementListGetModel.DateOfTransaction"/>
        public SortItem DateOfTransaction { get; set; } = new SortItem(nameof(BankStatementListGetModel.DateOfTransaction));
    }
}
