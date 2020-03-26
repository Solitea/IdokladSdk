using IdokladSdk.Requests.Core.Modifiers.Expand.Common;

namespace IdokladSdk.Requests.Core.Modifiers.Expand.Structure
{
    /// <summary>
    /// BankStatementExpand.
    /// </summary>
    public class BankStatementExpand : ExpandableEntity
    {
        /// <summary>
        /// Gets or sets numeric sequence.
        /// </summary>
        public NumericSequenceExpand NumericSequence { get; set; }

        /// <summary>
        /// Gets or sets bank account.
        /// </summary>
        public BankAccountExpand BankAccount { get; set; }
    }
}
