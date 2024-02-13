using System;
using IdokladSdk.Models.ReceivedDocumentPayments;
using IdokladSdk.Models.ReceivedInvoice;
using IdokladSdk.Requests.Core.Modifiers.Filters;
using IdokladSdk.Requests.Core.Modifiers.Filters.Common;

namespace IdokladSdk.Requests.ReceivedDocumentPayments.Filter
{
    /// <summary>
    /// Filterable properties of <see cref="ReceivedDocumentPaymentListGetModel"/>.
    /// </summary>
    public class ReceivedDocumentPaymentFilter : IdFilter
    {
        /// <inheritdoc cref="ReceivedDocumentPaymentListGetModel.DateOfPayment"/>
        public CompareFilterItem<DateTime> DateOfPayment { get; set; } = new CompareFilterItem<DateTime>(nameof(ReceivedDocumentPaymentListGetModel.DateOfPayment));

        /// <inheritdoc cref="ReceivedDocumentPaymentListGetModel.InvoiceId"/>
        public ContainArrayFilterItem InvoiceId { get; set; } = new ContainArrayFilterItem(nameof(ReceivedDocumentPaymentListGetModel.InvoiceId));

        /// <inheritdoc cref="ReceivedInvoiceListGetModel.PartnerId"/>
        public FilterItem<int> PartnerId { get; set; } = new FilterItem<int>(nameof(ReceivedInvoiceListGetModel.PartnerId));

        /// <inheritdoc cref="ReceivedDocumentPaymentListGetModel.PaymentOptionId"/>
        public FilterItem<int> PaymentOptionId { get; set; } = new FilterItem<int>(nameof(ReceivedDocumentPaymentListGetModel.PaymentOptionId));

        /// <inheritdoc cref="ReceivedDocumentPaymentListGetModel.InvoiceDocumentNumber"/>
        public ContainFilterItem<string> InvoiceDocumentNumber { get; set; } = new ContainFilterItem<string>(nameof(ReceivedDocumentPaymentListGetModel.InvoiceDocumentNumber));

        /// <inheritdoc cref="ReceivedDocumentPaymentListGetModel.Partner"/>
        public ContainFilterItem<string> Partner { get; set; } = new ContainFilterItem<string>(nameof(ReceivedDocumentPaymentListGetModel.Partner));
    }
}
