namespace IdokladSdk.Enums
{
    /// <summary>
    /// PaymentStatus.
    /// </summary>
    public enum PaymentStatus
    {
        /// <summary>
        /// Neuhrazeno
        /// </summary>
        Unpaid = 0,

        /// <summary>
        /// Uhrazeno
        /// </summary>
        Paid = 1,

        /// <summary>
        /// Částečně uhrazeno
        /// </summary>
        PartialPaid = 2,

        /// <summary>
        /// Přeplaceno
        /// </summary>
        Overpaid = 3,
    }
}
