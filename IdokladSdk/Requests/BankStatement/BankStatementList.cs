using IdokladSdk.Clients;
using IdokladSdk.Models.BankStatement;
using IdokladSdk.Requests.BankStatement.Filter;
using IdokladSdk.Requests.BankStatement.Sort;
using IdokladSdk.Requests.Core;

namespace IdokladSdk.Requests.BankStatement
{
    /// <summary>
    /// BankStatementList.
    /// </summary>
    public class BankStatementList : BaseList<BankStatementList, BankStatementClient, BankStatementListGetModel, BankStatementFilter, BankStatementSort>
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
