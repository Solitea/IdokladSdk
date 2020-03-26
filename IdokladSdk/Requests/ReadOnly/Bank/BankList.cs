using IdokladSdk.Clients.Readonly;
using IdokladSdk.Models.ReadOnly.Bank;
using IdokladSdk.Requests.Core;
using IdokladSdk.Requests.Core.Modifiers.Sort.BasicSorts;
using IdokladSdk.Requests.ReadOnly.Bank.Filter;

namespace IdokladSdk.Requests.ReadOnly.Bank
{
    /// <summary>
    /// List of banks.
    /// </summary>
    public class BankList : BaseList<BankList, BankClient, BankListGetModel, BankFilter, IdSort>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BankList"/> class.
        /// </summary>
        /// <param name="client">Bank client.</param>
        public BankList(BankClient client)
            : base(client)
        {
        }
    }
}
