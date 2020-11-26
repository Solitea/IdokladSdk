using IdokladSdk.Clients;
using IdokladSdk.Models.BankAccount;
using IdokladSdk.Requests.BankAccount.Filter;
using IdokladSdk.Requests.Core;
using IdokladSdk.Requests.Core.Modifiers.Sort.BasicSorts;

namespace IdokladSdk.Requests.BankAccount
{
    /// <summary>
    /// BankAccountList.
    /// </summary>
    public class BankAccountList : BaseList<BankAccountList, BankAccountClient, BankAccountListGetModel, BankAccountFilter, IdSort>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BankAccountList"/> class.
        /// </summary>
        /// <param name="client">Client.</param>
        public BankAccountList(BankAccountClient client)
            : base(client)
        {
        }
    }
}
