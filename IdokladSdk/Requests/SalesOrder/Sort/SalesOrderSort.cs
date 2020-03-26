using IdokladSdk.Models.SalesOrder;
using IdokladSdk.Requests.Core.Modifiers.Sort.BasicSorts;
using IdokladSdk.Requests.Core.Modifiers.Sort.Common;

namespace IdokladSdk.Requests.SalesOrder.Sort
{
    /// <summary>
    /// Sortable properties of <see cref="SalesOrderListGetModel"/>.
    /// </summary>
    public class SalesOrderSort : IdSort
    {
        /// <inheritdoc cref="SalesOrderListGetModel.DateOfIssue"/>
        public SortItem DateOfIssue { get; set; } = new SortItem(nameof(SalesOrderListGetModel.DateOfIssue));

        /// <inheritdoc cref="SalesOrderListGetModel.DocumentNumber"/>
        public SortItem DocumentNumber { get; set; } = new SortItem(nameof(SalesOrderListGetModel.DocumentNumber));
    }
}
