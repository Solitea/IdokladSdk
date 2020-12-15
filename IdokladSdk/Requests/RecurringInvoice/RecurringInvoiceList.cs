using IdokladSdk.Clients;
using IdokladSdk.Models.RecurringInvoice;
using IdokladSdk.Requests.Core;
using IdokladSdk.Requests.RecurringInvoice.Filter;
using IdokladSdk.Requests.RecurringInvoice.Sort;

namespace IdokladSdk.Requests.RecurringInvoice
{
    /// <summary>
    /// List of recurring invoices.
    /// </summary>
    public class RecurringInvoiceList : BaseList<RecurringInvoiceList, RecurringInvoiceClient, RecurringInvoiceListGetModel, RecurringInvoiceFilter, RecurringInvoiceSort>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="RecurringInvoiceList"/> class.
        /// </summary>
        /// <param name="client">Client.</param>
        public RecurringInvoiceList(RecurringInvoiceClient client)
            : base(client)
        {
        }
    }
}
