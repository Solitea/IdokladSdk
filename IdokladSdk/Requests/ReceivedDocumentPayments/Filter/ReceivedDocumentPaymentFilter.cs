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
        public FilterItem<int> InvoiceId { get; set; } = new CompareFilterItem<int>(nameof(ReceivedDocumentPaymentListGetModel.InvoiceId));

        /// <inheritdoc cref="ReceivedInvoiceListGetModel.PartnerId"/>
        public FilterItem<int> PartnerId { get; set; } = new CompareFilterItem<int>(nameof(ReceivedInvoiceListGetModel.PartnerId));

        /// <inheritdoc cref="ReceivedDocumentPaymentListGetModel.PaymentOptionId"/>
        public FilterItem<int> PaymentOptionId { get; set; } = new CompareFilterItem<int>(nameof(ReceivedDocumentPaymentListGetModel.PaymentOptionId));

        /// <inheritdoc cref="ReceivedDocumentPaymentListGetModel.InvoiceDocumentNumber"/>
        public CompareFilterItem<string> InvoiceDocumentNumber { get; set; } = new CompareFilterItem<string>(nameof(ReceivedDocumentPaymentListGetModel.InvoiceDocumentNumber));

        /// <inheritdoc cref="ReceivedDocumentPaymentListGetModel.Partner"/>
        public CompareFilterItem<string> Partner { get; set; } = new CompareFilterItem<string>(nameof(ReceivedDocumentPaymentListGetModel.Partner));
    }
}
