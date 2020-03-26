using IdokladSdk.Clients;
using IdokladSdk.Models.ProformaInvoice;
using IdokladSdk.Requests.Core;
using IdokladSdk.Requests.Core.Modifiers.Expand.Structure;

namespace IdokladSdk.Requests.ProformaInvoice
{
    /// <summary>
    /// ProformaInvoiceDetail.
    /// </summary>
    public class ProformaInvoiceDetail : ExpandableDetail<ProformaInvoiceDetail, ProformaInvoiceClient, ProformaInvoiceGetModel, ProformaInvoiceExpand>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ProformaInvoiceDetail"/> class.
        /// </summary>
        /// <param name="id">Id.</param>
        /// <param name="client">Client.</param>
        public ProformaInvoiceDetail(int id, ProformaInvoiceClient client)
            : base(id, client)
        {
        }
    }
}
