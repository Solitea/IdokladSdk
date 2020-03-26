using System.Collections.Generic;

namespace IdokladSdk.Models.Statistics
{
    /// <summary>
    /// InvoicingForPeriodGetModel.
    /// </summary>
    public class InvoicingForPeriodGetModel
    {
        /// <summary>
        /// Gets or sets Issued invoices.
        /// </summary>
        public List<InvoicingForPeriodPricesGetModel> IssuedInvoices { get; set; }

        /// <summary>
        /// Gets or sets Received invoices.
        /// </summary>
        public List<InvoicingForPeriodPricesGetModel> ReceivedInvoices { get; set; }
    }
}
