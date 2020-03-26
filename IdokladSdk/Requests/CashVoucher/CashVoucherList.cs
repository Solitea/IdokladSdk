using IdokladSdk.Clients;
using IdokladSdk.Models.CashVoucher;
using IdokladSdk.Requests.CashVoucher.Filter;
using IdokladSdk.Requests.Core;
using IdokladSdk.Requests.Core.Modifiers.Sort.BasicSorts;

namespace IdokladSdk.Requests.CashVoucher
{
    /// <summary>
    /// List of CashVouchers.
    /// </summary>
    public class CashVoucherList :
        BaseList<CashVoucherList, CashVoucherClient, CashVoucherListGetModel, CashVoucherFilter, IdSort>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CashVoucherList"/> class.
        /// </summary>
        /// <param name="client">Client.</param>
        public CashVoucherList(CashVoucherClient client)
            : base(client)
        {
        }
    }
}
