namespace IdokladSdk.Models.Statistics
{
    /// <summary>
    /// InvoicingForPeriodPricesGetModel.
    /// </summary>
    public class InvoicingForPeriodPricesGetModel
    {
        /// <summary>
        /// Gets or sets Period in numeric format.
        /// </summary>
        public int NumericPeriod { get; set; }

        /// <summary>
        /// Gets or sets Period.
        /// </summary>
        public string Period { get; set; }

        /// <summary>
        /// Gets or sets Total amount paid.
        /// </summary>
        public decimal TotalPaid { get; set; }

        /// <summary>
        /// Gets or sets Total amount unpaid.
        /// </summary>
        public decimal TotalUnpaid { get; set; }

        /// <summary>
        /// Gets or sets Total amount without VAT.
        /// </summary>
        public decimal TotalWithoutVat { get; set; }

        /// <summary>
        /// Gets or sets Total amount with VAT.
        /// </summary>
        public decimal TotalWithVat { get; set; }
    }
}
