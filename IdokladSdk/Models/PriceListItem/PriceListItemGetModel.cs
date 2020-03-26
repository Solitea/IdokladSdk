using IdokladSdk.Models.ReadOnly.Currency;

namespace IdokladSdk.Models.PriceListItem
{
    /// <summary>
    /// PriceListItemGetModel.
    /// </summary>
    public class PriceListItemGetModel : PriceListItemListGetModel
    {
        /// <summary>
        /// Gets or sets currency.
        /// </summary>
        public CurrencyGetModel Currency { get; set; }
    }
}
