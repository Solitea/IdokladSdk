using IdokladSdk.Models.IssuedDocumentPayment;
using IdokladSdk.Requests.Core.Modifiers.Sort.BasicSorts;
using IdokladSdk.Requests.Core.Modifiers.Sort.Common;

namespace IdokladSdk.Requests.IssuedDocumentPayment.Sort
{
    /// <summary>
    /// Sortable properties of <see cref="IssuedDocumentPaymentListGetModel"/>.
    /// </summary>
    public class IssuedDocumentPaymentSort : IdSort
    {
        /// <inheritdoc cref="IssuedDocumentPaymentListGetModel.DateOfPayment"/>
        public SortItem DateOfPayment { get; set; } = new SortItem(nameof(IssuedDocumentPaymentListGetModel.DateOfPayment));
    }
}
