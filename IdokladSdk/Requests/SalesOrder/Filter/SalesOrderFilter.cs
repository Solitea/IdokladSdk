using System;
using IdokladSdk.Enums;
using IdokladSdk.Models.Common;
using IdokladSdk.Models.DocumentAddress;
using IdokladSdk.Models.SalesOrder;
using IdokladSdk.Requests.Core.Modifiers.Filters;
using IdokladSdk.Requests.Core.Modifiers.Filters.Common;

namespace IdokladSdk.Requests.SalesOrder.Filter
{
    /// <summary>
    /// Filterable properties of <see cref="SalesOrderListGetModel"/>.
    /// </summary>
    public class SalesOrderFilter : IdFilter
    {
        /// <inheritdoc cref="SalesOrderListGetModel.DateOfIssue"/>
        public CompareFilterItem<DateTime> DateOfIssue { get; set; } = new CompareFilterItem<DateTime>(nameof(SalesOrderListGetModel.DateOfIssue));

        /// <inheritdoc cref="SalesOrderListGetModel.DateOfExpiration"/>
        public CompareFilterItem<DateTime> DateOfExpiration { get; set; } = new CompareFilterItem<DateTime>(nameof(SalesOrderListGetModel.DateOfExpiration));

        /// <inheritdoc cref="Metadata.DateLastChange"/>
        public CompareFilterItem<DateTime> DateLastChange { get; set; } = new CompareFilterItem<DateTime>(nameof(Metadata.DateLastChange));

        /// <inheritdoc cref="SalesOrderListGetModel.Exported"/>
        public FilterItem<ExportedState> Exported { get; set; } = new FilterItem<ExportedState>(nameof(SalesOrderListGetModel.Exported));

        /// <inheritdoc cref="SalesOrderListGetModel.CurrencyId"/>
        public FilterItem<int> CurrencyId { get; set; } = new FilterItem<int>(nameof(SalesOrderListGetModel.CurrencyId));

        /// <inheritdoc cref="SalesOrderListGetModel.Description"/>
        public ContainFilterItem<string> Description { get; set; } = new ContainFilterItem<string>(nameof(SalesOrderListGetModel.Description));

        /// <inheritdoc cref="SalesOrderListGetModel.DocumentNumber"/>
        public ContainFilterItem<string> DocumentNumber { get; set; } = new ContainFilterItem<string>(nameof(SalesOrderListGetModel.DocumentNumber));

        /// <inheritdoc cref="DocumentAddressModel.NickName"/>
        public ContainFilterItem<string> NickName { get; set; } = new ContainFilterItem<string>(nameof(DocumentAddressModel.NickName));

        /// <inheritdoc cref="SalesOrderListGetModel.PartnerId"/>
        public FilterItem<int> PartnerId { get; set; } = new FilterItem<int>(nameof(SalesOrderListGetModel.PartnerId));

        /// <inheritdoc cref="SalesOrderListGetModel.State"/>
        public FilterItem<SalesOrderState> State { get; set; } = new FilterItem<SalesOrderState>(nameof(SalesOrderListGetModel.State));

        /// <summary>
        /// Gets or sets numeric tag ids.
        /// </summary>
        public ContainTagIdFilterItem TagIds { get; set; } = new ContainTagIdFilterItem("TagIds");
    }
}
