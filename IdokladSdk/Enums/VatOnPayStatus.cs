namespace IdokladSdk.Enums
{
    /// <summary>
    /// VatOnPayStatus.
    /// </summary>
    public enum VatOnPayStatus
    {
        /// <summary>
        /// Není v režimu
        /// </summary>
        Disabled = 0,

        /// <summary>
        /// Je v režimu
        /// </summary>
        Enabled = 1,

        /// <summary>
        /// Faktura byla v režimu VatOnPay, uživatel režim ukončil přičemž faktura byla neuhrazené a je nutné ji vypořádat k poslednímu období v režimu
        /// </summary>
        InvoiceNeedsTaxing = 2
    }
}
