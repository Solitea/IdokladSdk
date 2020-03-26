using IdokladSdk.Clients;
using IdokladSdk.Models.CashRegister;
using IdokladSdk.Requests.Core;
using IdokladSdk.Requests.Core.Modifiers.Expand.Structure;

namespace IdokladSdk.Requests.CashRegister
{
    /// <summary>
    /// CashRegisterDetail.
    /// </summary>
    public class CashRegisterDetail : ExpandableDetail<CashRegisterDetail, CashRegisterClient, CashRegisterGetModel, CashRegisterExpand>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CashRegisterDetail"/> class.
        /// </summary>
        /// <param name="id">Id.</param>
        /// <param name="client">Client.</param>
        public CashRegisterDetail(int id, CashRegisterClient client)
            : base(id, client)
        {
        }
    }
}
