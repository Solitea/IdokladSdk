using IdokladSdk.Clients;
using IdokladSdk.Models.PriceListItem;
using IdokladSdk.Requests.Core;
using IdokladSdk.Requests.PriceListItem.Filter;
using IdokladSdk.Requests.PriceListItem.Sort;

namespace IdokladSdk.Requests.PriceListItem
{
    /// <summary>
    /// List of price list items.
    /// </summary>
    public class PriceListItemList : BaseList<PriceListItemList, PriceListItemClient, PriceListItemListGetModel, PriceListItemFilter, PriceListItemSort>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PriceListItemList"/> class.
        /// </summary>
        /// <param name="client">Price list items client.</param>
        public PriceListItemList(PriceListItemClient client)
            : base(client)
        {
        }
    }
}
