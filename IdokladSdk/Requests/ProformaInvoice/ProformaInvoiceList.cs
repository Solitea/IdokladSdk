using IdokladSdk.Clients;
using IdokladSdk.Models.ProformaInvoice;
using IdokladSdk.Requests.Core;
using IdokladSdk.Requests.ProformaInvoice.Filter;

namespace IdokladSdk.Requests.ProformaInvoice
{
    /// <summary>
    /// ProformaInvoiceList.
    /// </summary>
    public class ProformaInvoiceList : BaseList<ProformaInvoiceList, ProformaInvoiceClient, ProformaInvoiceListGetModel, ProformaInvoiceFilter, ProformaInvoiceSort>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ProformaInvoiceList"/> class.
        /// </summary>
        /// <param name="client">Client.</param>
        public ProformaInvoiceList(ProformaInvoiceClient client)
            : base(client)
        {
        }
    }
}
