namespace IdokladSdk.Models.BankStatement
{
    /// <summary>
    /// BankStatementPairingResult.
    /// </summary>
    public class BankStatementPairingResult
    {
        /// <summary>
        /// Gets or sets bank statement.
        /// </summary>
        public BankStatementGetModel CreatedBankStatement { get; set; }

        /// <summary>
        /// Gets or sets message.
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// Gets or sets paired invoice id.
        /// </summary>
        public int PairedInvoiceId { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether was paired.
        /// </summary>
        public bool WasPaired { get; set; }
    }
}
