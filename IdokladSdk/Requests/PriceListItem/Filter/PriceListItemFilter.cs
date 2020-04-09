using System;
using IdokladSdk.Models.Common;
using IdokladSdk.Models.PriceListItem;
using IdokladSdk.Requests.Core.Modifiers.Filters;
using IdokladSdk.Requests.Core.Modifiers.Filters.Common;

namespace IdokladSdk.Requests.PriceListItem.Filter
{
    /// <summary>
    /// Filterable properties of <see cref="PriceListItemListGetModel"/>.
    /// </summary>
    public class PriceListItemFilter : IdFilter
    {
        /// <inheritdoc cref="PriceListItemListGetModel.CurrencyId"/>
        public FilterItem<int> CurrencyId { get; set; } = new FilterItem<int>(nameof(PriceListItemListGetModel.CurrencyId));

        /// <inheritdoc cref="Metadata.DateLastChange"/>
        public CompareFilterItem<DateTime> DateLastChange { get; set; } = new CompareFilterItem<DateTime>(nameof(Metadata.DateLastChange));

        /// <summary>
        /// Gets or sets a value indicating whether item has stock movement.
        /// </summary>
        public FilterItem<bool> HasStockMovement { get; set; } = new FilterItem<bool>("HasStockMovement");

        /// <inheritdoc cref="PriceListItemListGetModel.Name"/>
        public ContainFilterItem<string> Name { get; set; } = new ContainFilterItem<string>(nameof(PriceListItemListGetModel.Name));

        /// <inheritdoc cref="PriceListItemListGetModel.StockBalance"/>
        public CompareFilterItem<decimal> StockBalance { get; set; } = new CompareFilterItem<decimal>(nameof(PriceListItemListGetModel.StockBalance));
    }
}
