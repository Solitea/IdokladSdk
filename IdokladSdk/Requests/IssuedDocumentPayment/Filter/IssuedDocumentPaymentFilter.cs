using System;
using IdokladSdk.Models.IssuedDocumentPayment;
using IdokladSdk.Requests.Core.Modifiers.Filters;
using IdokladSdk.Requests.Core.Modifiers.Filters.Common;

namespace IdokladSdk.Requests.IssuedDocumentPayment.Filter
{
    /// <summary>
    /// Filterable properties of <see cref="IssuedDocumentPaymentListGetModel"/>.
    /// </summary>
    public class IssuedDocumentPaymentFilter : IdFilter
    {
        /// <inheritdoc cref="IssuedDocumentPaymentListGetModel.InvoiceId"/>
        public FilterItem<int> InvoiceId { get; set; } = new CompareFilterItem<int>(nameof(IssuedDocumentPaymentListGetModel.InvoiceId));

        /// <inheritdoc cref="IssuedDocumentPaymentListGetModel.PaymentOptionId"/>
        public FilterItem<int> PaymentOptionId { get; set; } = new CompareFilterItem<int>(nameof(IssuedDocumentPaymentListGetModel.PaymentOptionId));

        /// <summary>
        /// Gets or sets partner id.
        /// </summary>
        public FilterItem<int> PartnerId { get; set; } = new CompareFilterItem<int>("PartnerId");

        /// <inheritdoc cref="IssuedDocumentPaymentListGetModel.DateOfPayment"/>
        public CompareFilterItem<DateTime> DateOfPayment { get; set; } = new CompareFilterItem<DateTime>(nameof(IssuedDocumentPaymentListGetModel.DateOfPayment));

        /// <inheritdoc cref="IssuedDocumentPaymentListGetModel.InvoiceDocumentNumber"/>
        public CompareFilterItem<string> InvoiceDocumentNumber { get; set; } = new CompareFilterItem<string>(nameof(IssuedDocumentPaymentListGetModel.InvoiceDocumentNumber));

        /// <inheritdoc cref="IssuedDocumentPaymentListGetModel.Partner"/>
        public CompareFilterItem<string> Partner { get; set; } = new CompareFilterItem<string>(nameof(IssuedDocumentPaymentListGetModel.Partner));
    }
}
