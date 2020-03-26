namespace IdokladSdk.Models.Statistics
{
    /// <summary>
    /// InvoicingForYearPricesGetModel.
    /// </summary>
    public class InvoicingForYearPricesGetModel
    {
        /// <summary>
        /// Gets or sets Total amount paid.
        /// </summary>
        public decimal Paid { get; set; }

        /// <summary>
        /// Gets or sets Total amount with VAT.
        /// </summary>
        public decimal TotalWithVat { get; set; }

        /// <summary>
        /// Gets or sets Total amount without VAT.
        /// </summary>
        public decimal WithoutVat { get; set; }
    }
}
