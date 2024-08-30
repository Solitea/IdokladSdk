namespace IdokladSdk.Enums
{
    public enum CashVoucherDependencyStatus
    {
        /// <summary>
        /// Unpaired
        /// </summary>
        Unpaired = 0,

        /// <summary>
        /// Paired
        /// </summary>
        PairedWithInvoice = 1,

        /// <summary>
        /// Originate from sales receipt accounting
        /// </summary>
        IsSummarySalesReceipt = 3,
    }
}
