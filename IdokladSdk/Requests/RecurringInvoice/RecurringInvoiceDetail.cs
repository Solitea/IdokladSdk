using IdokladSdk.Clients;
using IdokladSdk.Models.RecurringInvoice;
using IdokladSdk.Requests.Core;
using IdokladSdk.Requests.Core.Modifiers.Expand.Structure;

namespace IdokladSdk.Requests.RecurringInvoice
{
    /// <summary>
    /// Detail of recurring invoice.
    /// </summary>
    public class RecurringInvoiceDetail :
        ExpandableDetail<RecurringInvoiceDetail, RecurringInvoiceClient, RecurringInvoiceGetModel, RecurringInvoiceExpand>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="RecurringInvoiceDetail"/> class.
        /// Detail issued invoice.
        /// </summary>
        /// <param name="id">Id.</param>
        /// <param name="client">Client.</param>
        public RecurringInvoiceDetail(int id, RecurringInvoiceClient client)
            : base(id, client)
        {
        }
    }
}
