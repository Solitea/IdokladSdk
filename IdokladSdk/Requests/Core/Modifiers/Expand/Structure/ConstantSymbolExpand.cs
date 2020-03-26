using IdokladSdk.Requests.Core.Modifiers.Expand.Common;

namespace IdokladSdk.Requests.Core.Modifiers.Expand.Structure
{
    /// <summary>
    /// ConstantSymbolExpand.
    /// </summary>
    public class ConstantSymbolExpand : ExpandableEntity
    {
        /// <summary>
        /// Gets country.
        /// </summary>
        public CountryExpand Country { get; }
    }
}
