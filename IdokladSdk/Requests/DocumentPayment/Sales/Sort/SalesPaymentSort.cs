using IdokladSdk.Models.Payment.DocumentPayments.Sales.List;
using IdokladSdk.Requests.Core.Modifiers.Sort.BasicSorts;
using IdokladSdk.Requests.Core.Modifiers.Sort.Common;

namespace IdokladSdk.Requests.DocumentPayment.Sales.Sort
{
    /// <summary>
    /// Sortable properties of <see cref="SalesDocumentPaymentListGetModel"/>.
    /// </summary>
    public class SalesPaymentSort : IdSort
    {
        /// <inheritdoc cref="SalesDocumentPaymentListGetModel.DateOfPayment" />
        public SortItem DateOfPayment { get; set; } =
            new SortItem(nameof(SalesDocumentPaymentListGetModel.DateOfPayment));

        /// <inheritdoc cref="SalesDocumentPaymentListGetModel.PaidDocument" />
        public SortItem DocumentId { get; set; } = new SortItem("DocumentId");
    }
}
