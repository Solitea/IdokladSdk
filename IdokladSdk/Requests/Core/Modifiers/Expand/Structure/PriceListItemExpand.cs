using IdokladSdk.Requests.Core.Modifiers.Expand.Common;

namespace IdokladSdk.Requests.Core.Modifiers.Expand.Structure
{
    /// <summary>
    /// Expand model for PriceListItemExpand.
    /// </summary>
    public class PriceListItemExpand : ExpandableEntity
    {
        /// <summary>
        /// Gets currency.
        /// </summary>
        public CurrencyExpand Currency { get; }
    }
}
