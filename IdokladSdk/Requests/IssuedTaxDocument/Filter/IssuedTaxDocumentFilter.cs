using System;
using IdokladSdk.Enums;
using IdokladSdk.Models.IssuedTaxDocument.Get;
using IdokladSdk.Requests.Core.Modifiers.Filters;
using IdokladSdk.Requests.Core.Modifiers.Filters.Common;

namespace IdokladSdk.Requests.IssuedTaxDocument.Filter
{
    /// <summary>
    /// Filterable properties for <see cref="IssuedTaxDocumentGetModel"/>.
    /// </summary>
    public class IssuedTaxDocumentFilter : IdFilter
    {
        /// <inheritdoc cref="IssuedTaxDocumentGetModel.AccountedByInvoiceId"/>
        public FilterItem<int> AccountedByInvoiceId { get; set; } = new FilterItem<int>(nameof(IssuedTaxDocumentGetModel.AccountedByInvoiceId));

        /// <inheritdoc cref="IssuedTaxDocumentGetModel.CurrencyId"/>
        public FilterItem<int> CurrencyId { get; set; } = new FilterItem<int>(nameof(IssuedTaxDocumentGetModel.CurrencyId));

        /// <inheritdoc cref="IssuedTaxDocumentGetModel.DateOfIssue"/>
        public CompareFilterItem<DateTime> DateOfIssue { get; set; } = new CompareFilterItem<DateTime>(nameof(IssuedTaxDocumentGetModel.DateOfIssue));

        /// <inheritdoc cref="IssuedTaxDocumentGetModel.DateOfTaxing"/>
        public CompareFilterItem<DateTime> DateOfTaxing { get; set; } = new CompareFilterItem<DateTime>(nameof(IssuedTaxDocumentGetModel.DateOfTaxing));

        /// <inheritdoc cref="IssuedTaxDocumentGetModel.DocumentNumber"/>
        public CompareFilterItem<string> DocumentNumber { get; set; } = new CompareFilterItem<string>(nameof(IssuedTaxDocumentGetModel.DocumentNumber));

        /// <inheritdoc cref="IssuedTaxDocumentGetModel.Exported"/>
        public FilterItem<ExportedState> Exported { get; set; } = new FilterItem<ExportedState>(nameof(IssuedTaxDocumentGetModel.Exported));

        /// <inheritdoc cref="IssuedTaxDocumentGetModel.PartnerId"/>
        public FilterItem<int> PartnerId { get; set; } = new FilterItem<int>(nameof(IssuedTaxDocumentGetModel.PartnerId));

        /// <inheritdoc cref="IssuedTaxDocumentGetModel.PaymentId"/>
        public FilterItem<int> PaymentId { get; set; } = new FilterItem<int>(nameof(IssuedTaxDocumentGetModel.PaymentId));

        /// <inheritdoc cref="IssuedTaxDocumentGetModel.ProformaInvoiceId"/>
        public FilterItem<int> ProformaInvoiceId { get; set; } = new FilterItem<int>(nameof(IssuedTaxDocumentGetModel.ProformaInvoiceId));
    }
}
