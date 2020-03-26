using IdokladSdk.Requests.Core.Modifiers.Expand.Common;

namespace IdokladSdk.Requests.Core.Modifiers.Expand.Structure
{
    /// <summary>
    /// Expand for Bank.
    /// </summary>
    public class BankExpand : ExpandableEntity
    {
        /// <summary>
        /// Gets country.
        /// </summary>
        public CountryExpand Country { get; }
    }
}
