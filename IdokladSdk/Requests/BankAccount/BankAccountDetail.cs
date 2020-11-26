using IdokladSdk.Clients;
using IdokladSdk.Models.BankAccount;
using IdokladSdk.Requests.Core;
using IdokladSdk.Requests.Core.Modifiers.Expand.Structure;

namespace IdokladSdk.Requests.BankAccount
{
    /// <summary>
    /// BankAccountDetail.
    /// </summary>
    public class BankAccountDetail : ExpandableDetail<BankAccountDetail, BankAccountClient, BankAccountGetModel, BankAccountExpand>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BankAccountDetail"/> class.
        /// </summary>
        /// <param name="id">Id.</param>
        /// <param name="client">Client.</param>
        public BankAccountDetail(int id, BankAccountClient client)
            : base(id, client)
        {
        }
    }
}
