using IdokladSdk.Models.BankAccount;
using IdokladSdk.Models.NumericSequence;

namespace IdokladSdk.Models.BankStatement
{
    /// <summary>
    /// BankStatementGetModel.
    /// </summary>
    public class BankStatementGetModel : BankStatementListGetModel
    {
        /// <summary>
        /// Gets or sets numeric sequence.
        /// </summary>
        public NumericSequenceGetModel NumericSequence { get; set; }

        /// <summary>
        /// Gets or sets bank account.
        /// </summary>
        public BankAccountGetModel BankAccount { get; set; }
    }
}
