using IdokladSdk.Requests.Core.Modifiers.Expand.Common;

namespace IdokladSdk.Requests.Core.Modifiers.Expand.Structure
{
    /// <summary>
    /// VatRateExpand.
    /// </summary>
    public class VatRateExpand : ExpandableEntity
    {
        /// <summary>
        /// Gets country.
        /// </summary>
        public CountryExpand Country { get; }
    }
}
