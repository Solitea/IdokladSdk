using IdokladSdk.Clients;
using IdokladSdk.Models.CashVoucher;
using IdokladSdk.Requests.Core;
using IdokladSdk.Requests.Core.Modifiers.Expand.Structure;

namespace IdokladSdk.Requests.CashVoucher
{
    /// <summary>
    /// Detail of CashVoucher.
    /// </summary>
    public class CashVoucherDetail : ExpandableDetail<CashVoucherDetail, CashVoucherClient, CashVoucherGetModel, CashVoucherExpand>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CashVoucherDetail"/> class.
        /// </summary>
        /// <param name="id">Entity Id.</param>
        /// <param name="client">Client.</param>
        public CashVoucherDetail(int id, CashVoucherClient client)
            : base(id, client)
        {
        }
    }
}
