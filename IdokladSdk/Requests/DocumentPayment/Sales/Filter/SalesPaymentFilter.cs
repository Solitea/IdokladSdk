using System;
using IdokladSdk.Models.Payment.DocumentPayments.Sales.List;
using IdokladSdk.Requests.Core.Modifiers.Filters;
using IdokladSdk.Requests.Core.Modifiers.Filters.Common;

namespace IdokladSdk.Requests.DocumentPayment.Sales.Filter
{
    /// <summary>
    /// Filterable properties for <see cref="SalesPaymentFilter"/>.
    /// </summary>
    public class SalesPaymentFilter : IdFilter
    {
        /// <inheritdoc cref="SalesDocumentPaymentListGetModel.PaidDocument"/>
        public FilterItem<int> PartnerId { get; set; } = new FilterItem<int>(nameof(SalesDocumentPaymentListGetModel.PaidDocument.PartnerId));

        /// <inheritdoc cref="SalesDocumentPaymentListGetModel.PaidDocument"/>
        public ContainFilterItem<string> PartnerName { get; set; } = new ContainFilterItem<string>(nameof(SalesDocumentPaymentListGetModel.PaidDocument.PartnerName));

        /// <inheritdoc cref="SalesDocumentPaymentListGetModel"/>
        public FilterItem<int> PaymentOptionId { get; set; } = new FilterItem<int>(nameof(SalesDocumentPaymentListGetModel.PaymentOptionId));

        /// <inheritdoc cref="SalesDocumentPaymentListGetModel"/>
        public CompareFilterItem<DateTime> DateOfPayment { get; set; } = new CompareFilterItem<DateTime>(nameof(SalesDocumentPaymentListGetModel.DateOfPayment));

        /// <inheritdoc cref="SalesDocumentPaymentListGetModel.PaidDocument"/>
        public ContainFilterItem<string> DocumentNumber { get; set; } = new ContainFilterItem<string>(nameof(SalesDocumentPaymentListGetModel.PaidDocument.DocumentNumber));

        /// <inheritdoc cref="SalesDocumentPaymentListGetModel.PaidDocument"/>
        public FilterItem<int> DocumentId { get; set; } = new FilterItem<int>("DocumentId");
    }
}
