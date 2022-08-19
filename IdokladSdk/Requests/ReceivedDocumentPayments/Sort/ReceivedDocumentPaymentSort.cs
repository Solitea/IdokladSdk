using IdokladSdk.Models.ReceivedDocumentPayments;
using IdokladSdk.Requests.Core.Modifiers.Sort.BasicSorts;
using IdokladSdk.Requests.Core.Modifiers.Sort.Common;

namespace IdokladSdk.Requests.ReceivedDocumentPayments.Sort
{
    /// <summary>
    /// Sortable properties of <see cref="ReceivedDocumentPaymentListGetModel"/>.
    /// </summary>
    public class ReceivedDocumentPaymentSort : IdSort
    {
        /// <inheritdoc cref="ReceivedDocumentPaymentListGetModel.DateOfPayment"/>
        public SortItem DateOfPayment { get; set; } = new SortItem(nameof(ReceivedDocumentPaymentListGetModel.DateOfPayment));
    }
}
