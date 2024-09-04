using IdokladSdk.Models.CashVoucher;
using IdokladSdk.Requests.Core.Modifiers.Sort.BasicSorts;
using IdokladSdk.Requests.Core.Modifiers.Sort.Common;

namespace IdokladSdk.Requests.CashVoucher.Sort
{
    /// <summary>
    /// Sortable properties of <see cref="CashVoucherListGetModel"/>.
    /// </summary>
    public class CashVoucherSort : IdSort
    {
        /// <inheritdoc cref="CashVoucherListGetModel.DateOfTransaction"/>
        public SortItem DateOfTransaction { get; set; } = new SortItem(nameof(CashVoucherListGetModel.DateOfTransaction));
    }
}
