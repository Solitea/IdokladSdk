using IdokladSdk.Clients;
using IdokladSdk.Models.CashRegister;
using IdokladSdk.Requests.CashRegister.Filter;
using IdokladSdk.Requests.Core;
using IdokladSdk.Requests.Core.Modifiers.Sort.BasicSorts;

namespace IdokladSdk.Requests.CashRegister
{
    /// <summary>
    /// CashRegisterList.
    /// </summary>
    public class CashRegisterList : BaseList<CashRegisterList, CashRegisterClient, CashRegisterListGetModel, CashRegisterFilter, IdSort>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CashRegisterList"/> class.
        /// </summary>
        /// <param name="client">Client.</param>
        public CashRegisterList(CashRegisterClient client)
            : base(client)
        {
        }
    }
}
