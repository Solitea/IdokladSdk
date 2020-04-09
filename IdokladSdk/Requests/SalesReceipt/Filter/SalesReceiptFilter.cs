using System;
using IdokladSdk.Enums;
using IdokladSdk.Models.SalesReceipt;
using IdokladSdk.Requests.Core.Modifiers.Filters;
using IdokladSdk.Requests.Core.Modifiers.Filters.Common;

namespace IdokladSdk.Requests.SalesReceipt.Filter
{
    /// <summary>
    /// Filterable properties of <see cref="SalesReceiptListGetModel"/>.
    /// </summary>
    public class SalesReceiptFilter : IdFilter
    {
        /// <inheritdoc cref="SalesReceiptListGetModel.DateOfIssue"/>
        public CompareFilterItem<DateTime> DateOfIssue { get; set; } = new CompareFilterItem<DateTime>(nameof(SalesReceiptListGetModel.DateOfIssue));

        /// <inheritdoc cref="SalesReceiptListGetModel.Exported"/>
        public FilterItem<ExportedState> Exported { get; set; } = new FilterItem<ExportedState>(nameof(SalesReceiptListGetModel.Exported));

        /// <inheritdoc cref="SalesReceiptListGetModel.SalesPosEquipmentId"/>
        public FilterItem<ExportedState> SalesPosEquipmentId { get; set; } = new FilterItem<ExportedState>(nameof(SalesReceiptListGetModel.SalesPosEquipmentId));

        /// <summary>
        /// Gets or sets numeric tag ids.
        /// </summary>
        public ContainIdFilterItem TagIds { get; set; } = new ContainIdFilterItem("TagIds");
    }
}
