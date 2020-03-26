using IdokladSdk.Clients;
using IdokladSdk.Models.PriceListItem;
using IdokladSdk.Requests.Core;
using IdokladSdk.Requests.Core.Modifiers.Expand.Structure;

namespace IdokladSdk.Requests.PriceListItem
{
    /// <summary>
    /// Detail of price list item.
    /// </summary>
    public class PriceListItemDetail : ExpandableDetail<PriceListItemDetail, PriceListItemClient, PriceListItemGetModel, PriceListItemExpand>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PriceListItemDetail"/> class.
        /// </summary>
        /// <param name="id">Price list item id.</param>
        /// <param name="client">Price list item client.</param>
        public PriceListItemDetail(int id, PriceListItemClient client)
            : base(id, client)
        {
        }
    }
}
