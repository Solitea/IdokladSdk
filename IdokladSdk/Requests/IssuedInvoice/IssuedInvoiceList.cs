using IdokladSdk.Clients;
using IdokladSdk.Models.IssuedInvoice;
using IdokladSdk.Requests.Core;
using IdokladSdk.Requests.IssuedInvoice.Filter;
using IdokladSdk.Requests.IssuedInvoice.Sort;

namespace IdokladSdk.Requests.IssuedInvoice
{
    /// <summary>
    /// List of issued invoices.
    /// </summary>
    public class IssuedInvoiceList : BaseList<IssuedInvoiceList, IssuedInvoiceClient, IssuedInvoiceListGetModel, IssuedInvoiceFilter, IssuedInvoiceSort>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="IssuedInvoiceList"/> class.
        /// </summary>
        /// <param name="client">Client.</param>
        public IssuedInvoiceList(IssuedInvoiceClient client)
            : base(client)
        {
        }
    }
}
