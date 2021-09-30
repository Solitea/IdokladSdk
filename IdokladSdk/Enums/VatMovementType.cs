namespace IdokladSdk.Enums
{
    /// <summary>
    /// VAT movement type.
    /// </summary>
    public enum VatMovementType
    {
        /// <summary>
        /// Without restrictions.
        /// </summary>
        None = 0,

        /// <summary>
        /// Input VAT movement.
        /// </summary>
        Entry = 1,

        /// <summary>
        /// Output VAT movement.
        /// </summary>
        Issue = -1
    }
}
