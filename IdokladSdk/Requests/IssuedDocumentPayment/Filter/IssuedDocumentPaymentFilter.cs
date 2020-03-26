using System;
using IdokladSdk.Models.IssuedDocumentPayment;
using IdokladSdk.Requests.Core.Modifiers.Filters.Common;

namespace IdokladSdk.Requests.IssuedDocumentPayment.Filter
{
    /// <summary>
    /// Filterable properties of <see cref="IssuedDocumentPaymentListGetModel"/>.
    /// </summary>
    public class IssuedDocumentPaymentFilter
    {
        /// <inheritdoc cref="IssuedDocumentPaymentListGetModel.Id"/>
        public CompareFilterItem<int> Id { get; set; } = new CompareFilterItem<int>(nameof(IssuedDocumentPaymentListGetModel.Id));

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
    }
}
