using IdokladSdk.Clients;
using IdokladSdk.Models.Contact;
using IdokladSdk.Requests.Core;
using IdokladSdk.Requests.Core.Modifiers.Filters;
using IdokladSdk.Requests.Core.Modifiers.Sort.BasicSorts;

namespace IdokladSdk.Requests.Contact
{
    /// <summary>
    /// List of contacts.
    /// </summary>
    public class ContactList : BaseList<ContactList, ContactClient, ContactListGetModel, ContactFilter, IdSort>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ContactList"/> class.
        /// </summary>
        /// <param name="client">Contact client.</param>
        public ContactList(ContactClient client)
            : base(client)
        {
        }
    }
}
