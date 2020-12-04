namespace IdokladSdk.Models.Account
{
    /// <summary>
    /// AutomaticPairPaymentsSettingsGetModel.
    /// </summary>
    public class AutomaticPairPaymentsSettingsGetModel
    {
        /// <summary>
        /// Gets or sets bank statement mail for pairing.
        /// </summary>
        public string BankStatementMail { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether agenda has automatic pair payments.
        /// </summary>
        public bool HasAutomaticPairPayments { get; set; }
    }
}
