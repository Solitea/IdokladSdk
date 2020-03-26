using IdokladSdk.Clients;
using IdokladSdk.Models.ReceivedInvoice;
using IdokladSdk.Requests.Core;
using IdokladSdk.Requests.ReceivedInvoice.Filter;
using IdokladSdk.Requests.ReceivedInvoice.Sort;

namespace IdokladSdk.Requests.ReceivedInvoice
{
    /// <summary>
    /// Selectable properties of <see cref="ReceivedInvoiceListGetModel"/>.
    /// </summary>
    public class ReceivedInvoiceList : BaseList<ReceivedInvoiceList, ReceivedInvoiceClient, ReceivedInvoiceListGetModel, ReceivedInvoiceFilter, ReceivedInvoiceSort>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ReceivedInvoiceList"/> class.
        /// </summary>
        /// <param name="client">Client.</param>
        public ReceivedInvoiceList(ReceivedInvoiceClient client)
            : base(client)
        {
        }
    }
}
