using IdokladSdk.Requests.Core.Modifiers.Expand.Common;

namespace IdokladSdk.Requests.Core.Modifiers.Expand.Structure
{
    /// <summary>
    /// Expand model for Contact.
    /// </summary>
    public class ContactExpand : ExpandableEntity
    {
        /// <summary>
        /// Gets bank.
        /// </summary>
        public BankExpand Bank { get; }

        /// <summary>
        /// Gets country.
        /// </summary>
        public CountryExpand Country { get; }
    }
}
