using System;
using IdokladSdk.Requests.Core.Modifiers.Filters.Common;

namespace IdokladSdk.Requests.StockMovement.Filter
{
    /// <summary>
    /// StockMovementFilter.
    /// </summary>
    public class StockMovementFilter
    {
        /// <summary>
        /// Gets or sets Amount.
        /// </summary>
        public FilterItem<decimal> Amount { get; set; } = new FilterItem<decimal>("Amount");

        /// <summary>
        /// Gets or sets DateOfMovement.
        /// </summary>
        public CompareFilterItem<DateTime> DateOfMovement { get; set; } =
            new CompareFilterItem<DateTime>("DateOfMovement");

        /// <summary>
        /// Gets or sets id.
        /// </summary>
        public CompareFilterItem<int> Id { get; set; } = new CompareFilterItem<int>("Id");

        /// <summary>
        /// Gets or sets PriceListItemId.
        /// </summary>
        public FilterItem<int> PriceListItemId { get; set; } = new FilterItem<int>("PriceListItemId");
    }
}
