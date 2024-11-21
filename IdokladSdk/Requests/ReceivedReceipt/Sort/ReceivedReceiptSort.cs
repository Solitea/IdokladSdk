using IdokladSdk.Models.ReceivedReceipt.List;
using IdokladSdk.Requests.Core.Modifiers.Sort.BasicSorts;
using IdokladSdk.Requests.Core.Modifiers.Sort.Common;

namespace IdokladSdk.Requests.ReceivedReceipt.Sort
{
    /// <summary>
    /// ReceivedReceiptSort.
    /// </summary>
    public class ReceivedReceiptSort : IdSort
    {
        /// <inheritdoc cref="ReceivedReceiptListGetModel.DateOfIssue"/>
        public SortItem DateOfIssue { get; set; } = new SortItem(nameof(ReceivedReceiptListGetModel.DateOfIssue));

        /// <inheritdoc cref="ReceivedReceiptListGetModel.Description"/>
        public SortItem Description { get; set; } = new SortItem(nameof(ReceivedReceiptListGetModel.Description));
    }
}
