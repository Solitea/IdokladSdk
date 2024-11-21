using System;
using IdokladSdk.Models.Payment.DocumentPayments.Purchases.List;
using IdokladSdk.Requests.Core.Modifiers.Filters.Common;

namespace IdokladSdk.Requests.DocumentPayment.Purchases.Filter
{
    /// <summary>
    /// PurchasesPaymentFilter.
    /// </summary>
    public class PurchasesPaymentFilter
    {
        /// <inheritdoc cref="PurchaseDocumentPaymentListGetModel"/>
        public CompareFilterItem<DateTime> DateOfPayment { get; set; } =
            new CompareFilterItem<DateTime>(nameof(PurchaseDocumentPaymentListGetModel.DateOfPayment));

        /// <inheritdoc cref="PurchaseDocumentPaymentListGetModel.PaidDocument"/>
        public ContainArrayFilterItem DocumentId { get; set; } = new ContainArrayFilterItem("DocumentId");

        /// <inheritdoc cref="PurchaseDocumentPaymentListGetModel.PaidDocument"/>
        public ContainFilterItem<string> DocumentNumber { get; set; } =
            new ContainFilterItem<string>(nameof(PurchaseDocumentPaymentListGetModel.PaidDocument.DocumentNumber));

        /// <inheritdoc cref="PurchaseDocumentPaymentListGetModel.PaidDocument"/>
        public FilterItem<int> PartnerId { get; set; } =
            new FilterItem<int>(nameof(PurchaseDocumentPaymentListGetModel.PaidDocument.PartnerId));

        /// <inheritdoc cref="PurchaseDocumentPaymentListGetModel.PaidDocument"/>
        public ContainFilterItem<string> PartnerName { get; set; } =
            new ContainFilterItem<string>(nameof(PurchaseDocumentPaymentListGetModel.PaidDocument.PartnerName));

        /// <inheritdoc cref="PurchaseDocumentPaymentListGetModel"/>
        public FilterItem<int> PaymentOptionId { get; set; } =
            new FilterItem<int>(nameof(PurchaseDocumentPaymentListGetModel.PaymentOptionId));
    }
}
