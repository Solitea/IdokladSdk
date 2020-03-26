using IdokladSdk.Clients;
using IdokladSdk.Models.IssuedInvoice;
using IdokladSdk.Requests.Core;
using IdokladSdk.Requests.Core.Modifiers.Expand.Structure;

namespace IdokladSdk.Requests.IssuedInvoice
{
    /// <summary>
    /// Detail of issued invoice.
    /// </summary>
    public class IssuedInvoiceDetail :
        ExpandableDetail<IssuedInvoiceDetail, IssuedInvoiceClient, IssuedInvoiceGetModel, IssuedInvoiceExpand>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="IssuedInvoiceDetail"/> class.
        /// Detail issued invoice.
        /// </summary>
        /// <param name="id">Id.</param>
        /// <param name="client">Client.</param>
        public IssuedInvoiceDetail(int id, IssuedInvoiceClient client)
            : base(id, client)
        {
        }
    }
}
