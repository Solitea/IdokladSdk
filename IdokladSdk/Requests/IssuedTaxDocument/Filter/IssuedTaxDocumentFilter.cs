using System;
using IdokladSdk.Enums;
using IdokladSdk.Models.DocumentAddress;
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
        /// <inheritdoc cref="IssuedTaxDocumentListGetModel.CorrectedDocumentId"/>
        public FilterItem<int?> CorrectedDocumentId { get; set; } = new FilterItem<int?>(nameof(IssuedTaxDocumentListGetModel.CorrectedDocumentId));

        /// <inheritdoc cref="IssuedTaxDocumentListGetModel.AccountedByInvoiceId"/>
        public FilterItem<int?> AccountedByInvoiceId { get; set; } = new FilterItem<int?>(nameof(IssuedTaxDocumentGetModel.AccountedByInvoiceId));

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

        /// <inheritdoc cref="IssuedTaxDocumentListGetModel.IsEInvoice"/>
        public FilterItem<bool> IsEInvoice { get; set; } = new FilterItem<bool>(nameof(IssuedTaxDocumentListGetModel.IsEInvoice));

        /// <inheritdoc cref="IssuedTaxDocumentListGetModel.EInvoiceChannel"/>
        public FilterItem<EInvoiceChannel> EInvoiceChannel { get; set; } = new FilterItem<EInvoiceChannel>(nameof(IssuedTaxDocumentListGetModel.EInvoiceChannel));

        /// <inheritdoc cref="IssuedTaxDocumentListGetModel.EInvoiceStatus"/>
        public FilterItem<EInvoiceStatus> EInvoiceStatus { get; set; } = new FilterItem<EInvoiceStatus>(nameof(IssuedTaxDocumentListGetModel.EInvoiceStatus));

        /// <inheritdoc cref="DocumentAddressModel.NickName"/>
        public ContainFilterItem<string> NickName { get; set; } = new ContainFilterItem<string>(nameof(DocumentAddressModel.NickName));

        /// <inheritdoc cref="IssuedTaxDocumentListGetModel.PartnerId"/>
        public FilterItem<int> PartnerId { get; set; } = new FilterItem<int>(nameof(IssuedTaxDocumentGetModel.PartnerId));

        /// <inheritdoc cref="IssuedTaxDocumentListGetModel.PaymentId"/>
        public FilterItem<int> PaymentId { get; set; } = new FilterItem<int>(nameof(IssuedTaxDocumentGetModel.PaymentId));

        /// <inheritdoc cref="IssuedTaxDocumentListGetModel.ProformaInvoiceId"/>
        public FilterItem<int> ProformaInvoiceId { get; set; } = new FilterItem<int>(nameof(IssuedTaxDocumentGetModel.ProformaInvoiceId));
    }
}
