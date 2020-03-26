using IdokladSdk.Models.ReadOnly.Bank;

namespace IdokladSdk.Models.BankAccount
{
    /// <summary>
    /// BankAccountGetModel.
    /// </summary>
    public class BankAccountGetModel : BankAccountListGetModel
    {
        /// <summary>
        /// Gets or sets bank.
        /// </summary>
        public BankGetModel Bank { get; set; }
    }
}
