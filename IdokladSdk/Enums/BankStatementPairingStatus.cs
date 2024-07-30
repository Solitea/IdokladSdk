namespace IdokladSdk.Enums
{
    /// <summary>
    /// BankStatementPairingStatus.
    /// </summary>
    public enum BankStatementPairingStatus
    {
        /// <summary>
        /// Gets or sets Unpaired.
        /// </summary>
        Unpaired = 0,

        /// <summary>
        /// Gets or sets Paired.
        /// </summary>
        Paired = 1,

        /// <summary>
        /// Gets or sets UnpairedDidntFindInvoice.
        /// </summary>
        UnpairedDidntFindInvoice = 2,

        /// <summary>
        /// Gets or sets UnpairedFoundManyVariableSymbol.
        /// </summary>
        UnpairedFoundManyVariableSymbol = 3,
    }
}
