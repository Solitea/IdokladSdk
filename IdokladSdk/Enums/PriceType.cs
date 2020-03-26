namespace IdokladSdk.Enums
{
    /// <summary>
    /// PriceType.
    /// </summary>
    public enum PriceType
    {
        /// <summary>
        /// Cena s daní
        /// </summary>
        /// <summary xml:lang="en">
        /// Price incl. VAT
        /// </summary>
        WithVat = 0,

        /// <summary>
        /// Cena bez daně
        /// </summary>
        /// <summary xml:lang="en">
        /// Price without VAT
        /// </summary>
        WithoutVat = 1,

        /// <summary>
        /// Pouze základ
        /// </summary>
        /// <summary xml:lang="en">
        /// Base only
        /// </summary>
        OnlyBase = 2
    }
}
