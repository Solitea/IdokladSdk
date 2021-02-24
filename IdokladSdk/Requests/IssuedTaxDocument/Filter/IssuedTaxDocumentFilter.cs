using System;
using IdokladSdk.Enums;
using IdokladSdk.Models.IssuedTaxDocument.Get;
using IdokladSdk.Models.IssuedTaxDocument.List;
using IdokladSdk.Requests.Core.Modifiers.Filters;
using IdokladSdk.Requests.Core.Modifiers.Filters.Common;

namespace IdokladSdk.Requests.IssuedTaxDocument.Filter
{
    /// <summary>
    /// Filterable properties for <see cref="IssuedTaxDocumentGetModel"/>.
    /// </summary>
    public class IssuedTaxDocumentFilter : IdFilter
    {
        /// <inheritdoc cref="IssuedTaxDocumentListGetModel.AccountedByInvoiceId"/>
        public FilterItem<int> AccountedByInvoiceId { get; set; } = new FilterItem<int>(nameof(IssuedTaxDocumentGetModel.AccountedByInvoiceId));

        /// <inheritdoc cref="IssuedTaxDocumentListGetModel.CurrencyId"/>
        public FilterItem<int> CurrencyId { get; set; } = new FilterItem<int>(nameof(IssuedTaxDocumentGetModel.CurrencyId));

        /// <inheritdoc cref="IssuedTaxDocumentListGetModel.DateOfIssue"/>
        public CompareFilterItem<DateTime> DateOfIssue { get; set; } = new CompareFilterItem<DateTime>(nameof(IssuedTaxDocumentGetModel.DateOfIssue));

        /// <inheritdoc cref="IssuedTaxDocumentListGetModel.DateOfTaxing"/>
        public CompareFilterItem<DateTime> DateOfTaxing { get; set; } = new CompareFilterItem<DateTime>(nameof(IssuedTaxDocumentGetModel.DateOfTaxing));

        /// <inheritdoc cref="IssuedTaxDocumentListGetModel.DocumentNumber"/>
        public ContainFilterItem<string> DocumentNumber { get; set; } = new ContainFilterItem<string>(nameof(IssuedTaxDocumentGetModel.DocumentNumber));

        /// <inheritdoc cref="IssuedTaxDocumentListGetModel.Exported"/>
        public FilterItem<ExportedState> Exported { get; set; } = new FilterItem<ExportedState>(nameof(IssuedTaxDocumentGetModel.Exported));

        /// <inheritdoc cref="IssuedTaxDocumentListGetModel.PartnerId"/>
        public FilterItem<int> PartnerId { get; set; } = new FilterItem<int>(nameof(IssuedTaxDocumentGetModel.PartnerId));

        /// <inheritdoc cref="IssuedTaxDocumentListGetModel.PaymentId"/>
        public FilterItem<int> PaymentId { get; set; } = new FilterItem<int>(nameof(IssuedTaxDocumentGetModel.PaymentId));

        /// <inheritdoc cref="IssuedTaxDocumentListGetModel.ProformaInvoiceId"/>
        public FilterItem<int> ProformaInvoiceId { get; set; } = new FilterItem<int>(nameof(IssuedTaxDocumentGetModel.ProformaInvoiceId));
    }
}
