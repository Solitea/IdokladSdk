﻿using System;
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
        public FilterItem<int> InvoiceId { get; set; } = new FilterItem<int>(nameof(IssuedDocumentPaymentListGetModel.InvoiceId));

        /// <inheritdoc cref="IssuedDocumentPaymentListGetModel.PaymentOptionId"/>
        public FilterItem<int> PaymentOptionId { get; set; } = new FilterItem<int>(nameof(IssuedDocumentPaymentListGetModel.PaymentOptionId));

        /// <summary>
        /// Gets or sets partner id.
        /// </summary>
        public FilterItem<int> PartnerId { get; set; } = new FilterItem<int>("PartnerId");

        /// <inheritdoc cref="IssuedDocumentPaymentListGetModel.DateOfPayment"/>
        public CompareFilterItem<DateTime> DateOfPayment { get; set; } = new CompareFilterItem<DateTime>(nameof(IssuedDocumentPaymentListGetModel.DateOfPayment));

        /// <inheritdoc cref="IssuedDocumentPaymentListGetModel.InvoiceDocumentNumber"/>
        public ContainFilterItem<string> InvoiceDocumentNumber { get; set; } = new ContainFilterItem<string>(nameof(IssuedDocumentPaymentListGetModel.InvoiceDocumentNumber));

        /// <inheritdoc cref="IssuedDocumentPaymentListGetModel.Partner"/>
        public ContainFilterItem<string> Partner { get; set; } = new ContainFilterItem<string>(nameof(IssuedDocumentPaymentListGetModel.Partner));
    }
}
