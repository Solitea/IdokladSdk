namespace IdokladSdk.Models.Statistics
{
    /// <summary>
    /// Invoice statistics for contact.
    /// </summary>
    public class ContactStatisticGetModel
    {
        /// <summary>
        /// Gets or sets Invoices total.
        /// </summary>
        public decimal IssuedInvoiceTotalWithVat { get; set; }

        /// <summary>
        /// Gets or sets Invoices count.
        /// </summary>
        public int IssuedInvoiceCount { get; set; }

        /// <summary>
        /// Gets or sets Unpaid invoices count.
        /// </summary>
        public int IssuedInvoiceUnpaidCount { get; set; }

        /// <summary>
        /// Gets or sets Paid invoices count.
        /// </summary>
        public int IssuedInvoicePaidCount { get; set; }

        /// <summary>
        /// Gets or sets Unpaid invoices after maturity count.
        /// </summary>
        public int IssuedInvoiceAfterMaturityCount { get; set; }
    }
}
