using System;
using IdokladSdk.Requests.Core.Modifiers.Filters;
using IdokladSdk.Requests.Core.Modifiers.Filters.Common;

namespace IdokladSdk.Requests.StockMovement.Filter
{
    /// <summary>
    /// StockMovementFilter.
    /// </summary>
    public class StockMovementFilter : IdFilter
    {
        /// <summary>
        /// Gets or sets Amount.
        /// </summary>
        public CompareFilterItem<decimal> Amount { get; set; } = new CompareFilterItem<decimal>("Amount");

        /// <summary>
        /// Gets or sets DateOfMovement.
        /// </summary>
        public CompareFilterItem<DateTime> DateOfMovement { get; set; } =
            new CompareFilterItem<DateTime>("DateOfMovement");

        /// <summary>
        /// Gets or sets PriceListItemId.
        /// </summary>
        public FilterItem<int> PriceListItemId { get; set; } = new FilterItem<int>("PriceListItemId");
    }
}
