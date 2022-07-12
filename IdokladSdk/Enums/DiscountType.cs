namespace IdokladSdk.Enums
{
    /// <summary>
    /// Discount type.
    /// </summary>
    public enum DiscountType : byte
    {
        /// <summary>
        /// None.
        /// </summary>
        None = 0,

        /// <summary>
        /// The type of discount used before introducing discounts on items.
        /// </summary>
        Grouped = 1,

        /// <summary>
        /// Individual discounts per items.
        /// </summary>
        Individual = 2,

        /// <summary>
        /// Total discount on document.
        /// </summary>
        OnDocument = 3
    }
}
