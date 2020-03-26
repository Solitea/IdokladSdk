namespace IdokladSdk.Enums
{
    /// <summary>
    /// IssuedInvoiceItemType.
    /// </summary>
    public enum IssuedInvoiceItemType
    {
        /// <summary>
        /// Normální položka faktury
        /// </summary>
        ItemTypeNormal = 0,

        /// <summary>
        /// Zaokrouhlovací typ polozky
        /// </summary>
        ItemTypeRound = 1,

        /// <summary>
        /// Odpočtová položka
        /// </summary>
        /// <summary xml:lang="en">
        /// Reduced item for accounted by proforma invoices
        /// </summary>
        ItemTypeReduce = 2,

        /// <summary>
        /// Slevová položka
        /// </summary>
        ItemTypeDiscount = 3
    }
}
