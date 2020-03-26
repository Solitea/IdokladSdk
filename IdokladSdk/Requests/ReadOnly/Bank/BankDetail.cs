using IdokladSdk.Clients.Readonly;
using IdokladSdk.Models.ReadOnly.Bank;
using IdokladSdk.Requests.Core;
using IdokladSdk.Requests.Core.Modifiers.Expand.Structure;

namespace IdokladSdk.Requests.ReadOnly.Bank
{
    /// <summary>
    /// Detail of bank.
    /// </summary>
    public class BankDetail : ExpandableDetail<BankDetail, BankClient, BankGetModel, BankExpand>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BankDetail"/> class.
        /// </summary>
        /// <param name="id">Bank id.</param>
        /// <param name="client">Bank client.</param>
        public BankDetail(int id, BankClient client)
            : base(id, client)
        {
        }
    }
}
