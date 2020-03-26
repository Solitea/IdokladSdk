using IdokladSdk.Models.IssuedInvoice;
using IdokladSdk.Requests.Core.Modifiers.Sort.BasicSorts;
using IdokladSdk.Requests.Core.Modifiers.Sort.Common;

namespace IdokladSdk.Requests.IssuedInvoice.Sort
{
    /// <summary>
    /// Sortable properties of <see cref="IssuedInvoiceListGetModel"/>.
    /// </summary>
    public class IssuedInvoiceSort : IdSort
    {
        /// <inheritdoc cref="IssuedInvoiceListGetModel.DateOfIssue"/>
        public SortItem DateOfIssue { get; set; } = new SortItem(nameof(IssuedInvoiceListGetModel.DateOfIssue));

        /// <inheritdoc cref="IssuedInvoiceListGetModel.DocumentNumber"/>
        public SortItem DocumentNumber { get; set; } = new SortItem(nameof(IssuedInvoiceListGetModel.DocumentNumber));
    }
}
