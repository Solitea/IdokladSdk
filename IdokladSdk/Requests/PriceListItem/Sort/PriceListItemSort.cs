using IdokladSdk.Models.PriceListItem;
using IdokladSdk.Requests.Core.Modifiers.Sort.BasicSorts;
using IdokladSdk.Requests.Core.Modifiers.Sort.Common;

namespace IdokladSdk.Requests.PriceListItem.Sort
{
    /// <summary>
    /// PriceListItemSort.
    /// </summary>
    public class PriceListItemSort : IdSort
    {
        /// <inheritdoc cref="PriceListItemListGetModel.Name"/>
        public SortItem Name { get; set; } = new SortItem(nameof(PriceListItemListGetModel.Name));
    }
}
