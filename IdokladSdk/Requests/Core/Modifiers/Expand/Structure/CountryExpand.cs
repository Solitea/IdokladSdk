using IdokladSdk.Requests.Core.Modifiers.Expand.Common;

namespace IdokladSdk.Requests.Core.Modifiers.Expand.Structure
{
    /// <summary>
    /// Expand model for Country.
    /// </summary>
    public class CountryExpand : ExpandableEntity
    {
        /// <summary>
        /// Gets currency.
        /// </summary>
        public CurrencyExpand Currency { get; }
    }
}
