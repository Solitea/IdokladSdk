using IdokladSdk.Clients;
using IdokladSdk.Models.BankStatement;
using IdokladSdk.Requests.Core;
using IdokladSdk.Requests.Core.Modifiers.Expand.Structure;

namespace IdokladSdk.Requests.BankStatement
{
    /// <summary>
    /// BankStatementDetail.
    /// </summary>
    public class BankStatementDetail : ExpandableDetail<BankStatementDetail, BankStatementClient, BankStatementGetModel, BankStatementExpand>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BankStatementDetail"/> class.
        /// </summary>
        /// <param name="id">Id.</param>
        /// <param name="client">Client.</param>
        public BankStatementDetail(int id, BankStatementClient client)
            : base(id, client)
        {
        }
    }
}
