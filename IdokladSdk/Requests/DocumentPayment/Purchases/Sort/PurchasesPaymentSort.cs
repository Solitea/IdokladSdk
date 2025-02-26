using IdokladSdk.Models.Payment.DocumentPayments.Purchases.List;
using IdokladSdk.Models.Payment.DocumentPayments.Sales.SubModels;
using IdokladSdk.Requests.Core.Modifiers.Sort.BasicSorts;
using IdokladSdk.Requests.Core.Modifiers.Sort.Common;

namespace IdokladSdk.Requests.DocumentPayment.Purchases.Sort
{
    /// <summary>
    /// PurchasesPaymentSort.
    /// </summary>
    public class PurchasesPaymentSort : IdSort
    {
        /// <inheritdoc cref="PurchaseDocumentPaymentListGetModel.DateOfPayment" />
        public SortItem DateOfPayment { get; set; } =
            new SortItem(nameof(PurchaseDocumentPaymentListGetModel.DateOfPayment));

        /// <inheritdoc cref="PaidDocument" />
        public SortItem DocumentId { get; set; } = new SortItem("DocumentId");
    }
}
