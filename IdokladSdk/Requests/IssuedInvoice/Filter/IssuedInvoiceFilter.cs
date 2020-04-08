using System;
using IdokladSdk.Enums;
using IdokladSdk.Models.Common;
using IdokladSdk.Models.IssuedInvoice;
using IdokladSdk.Requests.Core.Modifiers.Filters;
using IdokladSdk.Requests.Core.Modifiers.Filters.Common;

namespace IdokladSdk.Requests.IssuedInvoice.Filter
{
    /// <summary>
    /// Filterable properties for <see cref="IssuedInvoiceListGetModel"/>.
    /// </summary>
    public class IssuedInvoiceFilter : IdFilter
    {
        /// <inheritdoc cref="IssuedInvoiceListGetModel.ConstantSymbolId"/>
        public FilterItem<int> ConstantSymbolId { get; set; } = new FilterItem<int>(nameof(IssuedInvoiceListGetModel.ConstantSymbolId));

        /// <inheritdoc cref="IssuedInvoiceListGetModel.CurrencyId"/>
        public FilterItem<int> CurrencyId { get; set; } = new FilterItem<int>(nameof(IssuedInvoiceListGetModel.CurrencyId));

        /// <inheritdoc cref="Metadata.DateLastChange"/>
        public CompareFilterItem<DateTime> DateLastChange { get; set; } = new CompareFilterItem<DateTime>(nameof(Metadata.DateLastChange));

        /// <inheritdoc cref="IssuedInvoiceListGetModel.DateOfIssue"/>
        public CompareFilterItem<DateTime> DateOfIssue { get; set; } = new CompareFilterItem<DateTime>(nameof(IssuedInvoiceListGetModel.DateOfIssue));

        /// <inheritdoc cref="IssuedInvoiceListGetModel.DateOfMaturity"/>
        public CompareFilterItem<DateTime> DateOfMaturity { get; set; } = new CompareFilterItem<DateTime>(nameof(IssuedInvoiceListGetModel.DateOfMaturity));

        /// <inheritdoc cref="IssuedInvoiceListGetModel.DateOfPayment"/>
        public CompareFilterItem<DateTime> DateOfPayment { get; set; } = new CompareFilterItem<DateTime>(nameof(IssuedInvoiceListGetModel.DateOfPayment));

        /// <inheritdoc cref="IssuedInvoiceListGetModel.Description"/>
        public ContainFilterItem<string> Description { get; set; } = new ContainFilterItem<string>(nameof(IssuedInvoiceListGetModel.Description));

        /// <inheritdoc cref="IssuedInvoiceListGetModel.DocumentNumber"/>
        public ContainFilterItem<string> DocumentNumber { get; set; } = new ContainFilterItem<string>(nameof(IssuedInvoiceListGetModel.DocumentNumber));

        /// <inheritdoc cref="IssuedInvoiceListGetModel.Exported"/>
        public FilterItem<ExportedState> Exported { get; set; } = new FilterItem<ExportedState>(nameof(IssuedInvoiceListGetModel.Exported));

        /// <summary>
        /// Gets or sets a value indicating whether invoice is paid.
        /// </summary>
        public FilterItem<bool> IsPaid { get; set; } = new FilterItem<bool>("IsPaid");

        /// <summary>
        /// Gets or sets numeric sequence Id.
        /// </summary>
        public FilterItem<int> NumericSequenceId { get; set; } = new FilterItem<int>("NumericSequenceId");

        /// <inheritdoc cref="IssuedInvoiceListGetModel.PartnerId"/>
        public FilterItem<int> PartnerId { get; set; } = new FilterItem<int>("PurchaserId");
    }
}
