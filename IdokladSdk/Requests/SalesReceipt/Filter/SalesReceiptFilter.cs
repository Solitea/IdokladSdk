using System;
using IdokladSdk.Enums;
using IdokladSdk.Models.DocumentAddress;
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

        /// <inheritdoc cref="SalesReceiptListGetModel.DocumentNumber"/>
        public ContainFilterItem<string> DocumentNumber { get; set; } = new ContainFilterItem<string>(nameof(SalesReceiptListGetModel.DocumentNumber));

        /// <inheritdoc cref="SalesReceiptListGetModel.Exported"/>
        public FilterItem<ExportedState> Exported { get; set; } = new FilterItem<ExportedState>(nameof(SalesReceiptListGetModel.Exported));

        /// <inheritdoc cref="SalesReceiptListGetModel.Name"/>
        public ContainFilterItem<string> Name { get; set; } = new ContainFilterItem<string>(nameof(SalesReceiptListGetModel.Name));

        /// <inheritdoc cref="DocumentAddressModel.NickName"/>
        public ContainFilterItem<string> PartnerName { get; set; } = new ContainFilterItem<string>("PartnerName");

        /// <inheritdoc cref="SalesReceiptListGetModel.SalesPosEquipmentId"/>
        public FilterItem<int> SalesPosEquipmentId { get; set; } = new FilterItem<int>(nameof(SalesReceiptListGetModel.SalesPosEquipmentId));

        /// <summary>
        /// Gets or sets numeric tag ids.
        /// </summary>
        public ContainIdFilterItem TagIds { get; set; } = new ContainIdFilterItem("TagIds");
    }
}
