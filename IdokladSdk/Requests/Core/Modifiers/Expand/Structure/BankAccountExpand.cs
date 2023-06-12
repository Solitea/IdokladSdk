using IdokladSdk.Requests.Core.Modifiers.Expand.Common;

namespace IdokladSdk.Requests.Core.Modifiers.Expand.Structure
{
    /// <summary>
    /// BankAccountExpand.
    /// </summary>
    public class BankAccountExpand : ExpandableEntity
    {
        /// <summary>
        /// Gets or sets bank.
        /// </summary>
        public BankExpand Bank { get; set; }
    }
}
