namespace IdokladSdk.Models.Statistics
{
    /// <summary>
    /// InvoicingForYearGetModel.
    /// </summary>
    public class InvoicingForYearGetModel
    {
        /// <summary>
        /// Gets or sets Issued invoices.
        /// </summary>
        public InvoicingForYearPricesGetModel IssuedInvoices { get; set; }

        /// <summary>
        /// Gets or sets Received invoices.
        /// </summary>
        public InvoicingForYearPricesGetModel ReceivedInvoices { get; set; }
    }
}
