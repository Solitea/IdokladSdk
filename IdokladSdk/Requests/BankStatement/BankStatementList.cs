using IdokladSdk.Clients;
using IdokladSdk.Models.BankStatement;
using IdokladSdk.Requests.BankStatement.Filter;
using IdokladSdk.Requests.Core;
using IdokladSdk.Requests.Core.Modifiers.Sort.BasicSorts;

namespace IdokladSdk.Requests.BankStatement
{
    /// <summary>
    /// BankStatementList.
    /// </summary>
    public class BankStatementList : BaseList<BankStatementList, BankStatementClient, BankStatementListGetModel, BankStatementFilter, IdSort>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BankStatementList"/> class.
        /// </summary>
        /// <param name="client">Client.</param>
        public BankStatementList(BankStatementClient client)
            : base(client)
        {
        }
    }
}
