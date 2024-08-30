using System;
using IdokladSdk.Enums;
using IdokladSdk.Models.CashVoucher;
using IdokladSdk.Models.Common;
using IdokladSdk.Requests.Core.Modifiers.Filters;
using IdokladSdk.Requests.Core.Modifiers.Filters.Common;

namespace IdokladSdk.Requests.CashVoucher.Filter
{
    /// <summary>
    /// Filter for CashVoucher.
    /// </summary>
    public class CashVoucherFilter : IdFilter
    {
        /// <inheritdoc cref="CashVoucherListGetModel.CashRegisterId"/>
        public FilterItem<int> CashRegisterId { get; set; } = new FilterItem<int>(nameof(CashVoucherListGetModel.CashRegisterId));

        /// <inheritdoc cref="CashVoucherListGetModel.CurrencyId"/>
        public FilterItem<int> CurrencyId { get; set; } = new FilterItem<int>(nameof(CashVoucherListGetModel.CurrencyId));

        /// <inheritdoc cref="CashVoucherListGetModel.Exported"/>
        public CompareFilterItem<ExportedState> Exported { get; set; } = new CompareFilterItem<ExportedState>(nameof(CashVoucherListGetModel.Exported));

        /// <inheritdoc cref="CashVoucherListGetModel.IsSummarySalesReceipt"/>
        public CompareFilterItem<bool> IsSummarySalesReceipt { get; set; } = new CompareFilterItem<bool>(nameof(CashVoucherListGetModel.IsSummarySalesReceipt));

        /// <inheritdoc cref="CashVoucherListGetModel.MovementType"/>
        public CompareFilterItem<MovementType> MovementType { get; set; } = new CompareFilterItem<MovementType>(nameof(CashVoucherListGetModel.MovementType));

        /// <inheritdoc cref="Metadata.DateLastChange"/>
        public CompareFilterItem<DateTime> DateLastChange { get; set; } = new CompareFilterItem<DateTime>(nameof(Metadata.DateLastChange));

        /// <inheritdoc cref="CashVoucherListGetModel.DateOfTransaction"/>
        public CompareFilterItem<DateTime> DateOfTransaction { get; set; } = new CompareFilterItem<DateTime>(nameof(CashVoucherListGetModel.DateOfTransaction));

        /// <inheritdoc cref="CashVoucherListGetModel.DocumentNumber"/>
        public CompareFilterItem<string> DocumentNumber { get; set; } = new CompareFilterItem<string>(nameof(CashVoucherListGetModel.DocumentNumber));

        public CompareFilterItem<CashVoucherDependencyStatus> Status { get; set; } = new CompareFilterItem<CashVoucherDependencyStatus>(nameof(CashVoucherListGetModel.Status));

        /// <summary>
        /// Gets or sets numeric tag ids.
        /// </summary>
        public ContainTagIdFilterItem TagIds { get; set; } = new ContainTagIdFilterItem("TagIds");
    }
}
