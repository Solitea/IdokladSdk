namespace IdokladSdk.Models.Statistics
{
    /// <summary>
    /// AgendaSummaryGetModel.
    /// </summary>
    public class AgendaSummaryGetModel
    {
        /// <summary>
        /// Gets or sets Number of bank statements.
        /// </summary>
        public int BankStatements { get; set; }

        /// <summary>
        /// Gets or sets Number of cash vouchers.
        /// </summary>
        public int CashVouchers { get; set; }

        /// <summary>
        /// Gets or sets Number of contacts.
        /// </summary>
        public int Contacts { get; set; }

        /// <summary>
        /// Gets or sets Number of credit notes.
        /// </summary>
        public int CreditNotes { get; set; }

        /// <summary>
        /// Gets or sets Number of issued invoices.
        /// </summary>
        public int IssuedInvoices { get; set; }

        /// <summary>
        /// Gets or sets Number of pricelist items.
        /// </summary>
        public int PriceListItems { get; set; }

        /// <summary>
        /// Gets or sets Number of proforma invoices.
        /// </summary>
        public int ProformaInvoices { get; set; }

        /// <summary>
        /// Gets or sets Number of received invoices.
        /// </summary>
        public int ReceivedInvoices { get; set; }

        /// <summary>
        /// Gets or sets Number of recurring invoices.
        /// </summary>
        public int RecurringInvoices { get; set; }

        /// <summary>
        /// Gets or sets Number of registered sales.
        /// </summary>
        public int RegisteredSales { get; set; }

        /// <summary>
        /// Gets or sets Number of sales orders.
        /// </summary>
        public int SalesOrders { get; set; }

        /// <summary>
        /// Gets or sets Number of sales receipts.
        /// </summary>
        public int SalesReceipts { get; set; }
    }
}
