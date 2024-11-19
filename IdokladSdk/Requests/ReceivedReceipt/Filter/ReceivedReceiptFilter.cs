using System;
using IdokladSdk.Enums;
using IdokladSdk.Models.Common;
using IdokladSdk.Models.ReceivedReceipt.List;
using IdokladSdk.Requests.Core.Modifiers.Filters;
using IdokladSdk.Requests.Core.Modifiers.Filters.Common;

namespace IdokladSdk.Requests.ReceivedReceipt.Filter
{
    /// <summary>
    /// ReceivedReceiptFilter.
    /// </summary>
    public class ReceivedReceiptFilter : IdFilter
    {
        /// <inheritdoc cref="ReceivedReceiptListGetModel.CurrencyId"/>
        public FilterItem<int> CurrencyId { get; set; } =
            new FilterItem<int>(nameof(ReceivedReceiptListGetModel.CurrencyId));

        /// <inheritdoc cref="Metadata.DateLastChange"/>
        public CompareFilterItem<DateTime> DateLastChange { get; set; } =
            new CompareFilterItem<DateTime>(nameof(ReceivedReceiptListGetModel.Metadata.DateLastChange));

        /// <inheritdoc cref="ReceivedReceiptListGetModel.DateOfIssue"/>
        public CompareFilterItem<DateTime> DateOfIssue { get; set; } =
            new CompareFilterItem<DateTime>(nameof(ReceivedReceiptListGetModel.DateOfIssue));

        /// <inheritdoc cref="ReceivedReceiptListGetModel.Description"/>
        public ContainFilterItem<string> Description { get; set; } =
            new ContainFilterItem<string>(nameof(ReceivedReceiptListGetModel.Description));

        /// <inheritdoc cref="ReceivedReceiptListGetModel.DocumentNumber"/>
        public ContainFilterItem<string> DocumentNumber { get; set; } =
            new ContainFilterItem<string>(nameof(ReceivedReceiptListGetModel.DocumentNumber));

        /// <inheritdoc cref="ReceivedReceiptListGetModel.Exported"/>
        public FilterItem<ExportedState> Exported { get; set; } =
            new FilterItem<ExportedState>(nameof(ReceivedReceiptListGetModel.Exported));

        /// <inheritdoc cref="ReceivedReceiptListGetModel.Status"/>
        public FilterItem<ReceivedReceiptDependencyStatus> Status { get; set; } =
            new FilterItem<ReceivedReceiptDependencyStatus>(nameof(ReceivedReceiptListGetModel.Status));

        /// <summary>
        /// Gets or sets supplier ID.
        /// </summary>
        public FilterItem<int> PartnerId { get; set; } = new FilterItem<int>("PartnerId");

        /// <summary>
        /// Gets or sets supplier name.
        /// </summary>
        public ContainFilterItem<string> PartnerName { get; set; } =
            new ContainFilterItem<string>("PartnerName");

        /// <summary>
        /// Gets or sets numeric tag ids.
        /// </summary>
        public ContainTagIdFilterItem TagIds { get; set; } = new ContainTagIdFilterItem("TagIds");
    }
}
