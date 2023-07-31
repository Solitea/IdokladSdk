using System;
using IdokladSdk.Enums;
using IdokladSdk.Models.Common;
using IdokladSdk.Models.CreditNote;
using IdokladSdk.Models.DocumentAddress;
using IdokladSdk.Requests.Core.Modifiers.Filters;
using IdokladSdk.Requests.Core.Modifiers.Filters.Common;

namespace IdokladSdk.Requests.CreditNote.Filter
{
    /// <summary>
    /// Filterable properties for <see cref="CreditNoteListGetModel"/>.
    /// </summary>
    public class CreditNoteFilter : IdFilter
    {
        /// <inheritdoc cref="CreditNoteListGetModel.ConstantSymbolId"/>
        public FilterItem<int> ConstantSymbolId { get; set; } = new FilterItem<int>(nameof(CreditNoteListGetModel.ConstantSymbolId));

        /// <inheritdoc cref="CreditNoteListGetModel.CurrencyId"/>
        public FilterItem<int> CurrencyId { get; set; } = new FilterItem<int>(nameof(CreditNoteListGetModel.CurrencyId));

        /// <inheritdoc cref="Metadata.DateLastChange"/>
        public CompareFilterItem<DateTime> DateLastChange { get; set; } = new CompareFilterItem<DateTime>(nameof(Metadata.DateLastChange));

        /// <inheritdoc cref="CreditNoteListGetModel.DateOfIssue"/>
        public CompareFilterItem<DateTime> DateOfIssue { get; set; } = new CompareFilterItem<DateTime>(nameof(CreditNoteListGetModel.DateOfIssue));

        /// <inheritdoc cref="CreditNoteListGetModel.DateOfMaturity"/>
        public CompareFilterItem<DateTime> DateOfMaturity { get; set; } = new CompareFilterItem<DateTime>(nameof(CreditNoteListGetModel.DateOfMaturity));

        /// <inheritdoc cref="CreditNoteListGetModel.DateOfPayment"/>
        public CompareFilterItem<DateTime> DateOfPayment { get; set; } = new CompareFilterItem<DateTime>(nameof(CreditNoteListGetModel.DateOfPayment));

        /// <inheritdoc cref="Metadata.DateOfTaxing"/>
        public CompareFilterItem<DateTime> DateOfTaxing { get; set; } = new CompareFilterItem<DateTime>(nameof(CreditNoteListGetModel.DateOfTaxing));

        /// <inheritdoc cref="CreditNoteListGetModel.Description"/>
        public ContainFilterItem<string> Description { get; set; } = new ContainFilterItem<string>(nameof(CreditNoteListGetModel.Description));

        /// <inheritdoc cref="CreditNoteListGetModel.DocumentNumber"/>
        public ContainFilterItem<string> DocumentNumber { get; set; } = new ContainFilterItem<string>(nameof(CreditNoteListGetModel.DocumentNumber));

        /// <inheritdoc cref="CreditNoteListGetModel.Exported"/>
        public FilterItem<ExportedState> Exported { get; set; } = new FilterItem<ExportedState>(nameof(CreditNoteListGetModel.Exported));

        /// <summary>
        /// Gets or sets a value indicating whether invoice is paid.
        /// </summary>
        [Obsolete("Use PaymentStatus filter instead.")]
        public FilterItem<bool> IsPaid { get; set; } = new FilterItem<bool>("IsPaid");

        /// <inheritdoc cref="CreditNoteListGetModel.PaymentStatus"/>
        public FilterItem<PaymentStatus> PaymentStatus { get; set; } = new FilterItem<PaymentStatus>(nameof(CreditNoteListGetModel.PaymentStatus));

        /// <inheritdoc cref="DocumentAddressModel.NickName"/>
        public ContainFilterItem<string> NickName { get; set; } = new ContainFilterItem<string>(nameof(DocumentAddressModel.NickName));

        /// <summary>
        /// Gets or sets numeric sequence Id.
        /// </summary>
        public FilterItem<int> NumericSequenceId { get; set; } = new FilterItem<int>("NumericSequenceId");

        /// <inheritdoc cref="CreditNoteListGetModel.PartnerId"/>
        public FilterItem<int> PartnerId { get; set; } = new FilterItem<int>(nameof(CreditNoteListGetModel.PartnerId));

        /// <summary>
        /// Gets or sets numeric tag ids.
        /// </summary>
        public ContainIdFilterItem TagIds { get; set; } = new ContainIdFilterItem("TagIds");
    }
}
