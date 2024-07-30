namespace IdokladSdk.Enums
{
    /// <summary>
    /// BankMailHistoryStatus.
    /// </summary>
    public enum BankMailHistoryStatus
    {
        /// <summary>
        /// Gets or sets Unprocessed.
        /// </summary>
        Unprocessed = 0,

        /// <summary>
        /// Gets or sets Success.
        /// </summary>
        Success = 1,

        /// <summary>
        /// Gets or sets NoBankAccount.
        /// </summary>
        NoBankAccount = 2,

        /// <summary>
        /// Gets or sets BadMessage.
        /// </summary>
        BadMessage = 3,

        /// <summary>
        /// Gets or sets CurrencyCodeNotMatched.
        /// </summary>
        CurrencyCodeNotMatched = 4,

        /// <summary>
        /// Gets or sets NoSuitableParser.
        /// </summary>
        NoSuitableParser = 5,

        /// <summary>
        /// Gets or sets NotMessageForSelectedParser.
        /// </summary>
        NotMessageForSelectedParser = 6,

        /// <summary>
        /// Gets or sets NotOwnKbBankAccount.
        /// </summary>
        NotOwnKbBankAccount = 7,

        /// <summary>
        /// Gets or sets BothOwnKbBankAccounts.
        /// </summary>
        BothOwnKbBankAccounts = 8,

        /// <summary>
        /// Gets or sets UnspecifiedError.
        /// </summary>
        UnspecifiedError = 9,

        /// <summary>
        /// Gets or sets InvalidAccountNumber.
        /// </summary>
        InvalidAccountNumber = 10,

        /// <summary>
        /// Gets or sets ZeroItemAmount.
        /// </summary>
        ZeroItemAmount = 11,

        /// <summary>
        /// Gets or sets InvalidIban.
        /// </summary>
        InvalidIban = 12,

        /// <summary>
        /// Gets or sets VariableSymbolTooLong.
        /// </summary>
        VariableSymbolTooLong = 13,
    }
}
