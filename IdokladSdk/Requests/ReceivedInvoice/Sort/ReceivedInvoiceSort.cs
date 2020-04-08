using IdokladSdk.Models.ReceivedInvoice;
using IdokladSdk.Requests.Core.Modifiers.Sort.BasicSorts;
using IdokladSdk.Requests.Core.Modifiers.Sort.Common;

namespace IdokladSdk.Requests.ReceivedInvoice.Sort
{
    /// <summary>
    /// ReceivedInvoiceSort.
    /// </summary>
    public class ReceivedInvoiceSort : IdSort
    {
        /// <inheritdoc cref="ReceivedInvoiceListGetModel.DateOfIssue"/>
        public SortItem DateOfIssue { get; set; } = new SortItem(nameof(ReceivedInvoiceListGetModel.DateOfIssue));

        /// <inheritdoc cref="ReceivedInvoiceListGetModel.DateOfReceiving"/>
        public SortItem DateOfReceiving { get; set; } = new SortItem(nameof(ReceivedInvoiceListGetModel.DateOfReceiving));

        /// <inheritdoc cref="ReceivedInvoiceListGetModel.DocumentNumber"/>
        public SortItem DocumentNumber { get; set; } = new SortItem(nameof(ReceivedInvoiceListGetModel.DocumentNumber));
    }
}
