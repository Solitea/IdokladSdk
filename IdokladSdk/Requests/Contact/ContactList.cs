using IdokladSdk.Clients;
using IdokladSdk.Models.Contact;
using IdokladSdk.Requests.Contact.Sort;
using IdokladSdk.Requests.Core;
using IdokladSdk.Requests.Core.Modifiers.Filters;

namespace IdokladSdk.Requests.Contact
{
    /// <summary>
    /// List of contacts.
    /// </summary>
    public class ContactList : BaseList<ContactList, ContactClient, ContactListGetModel, ContactFilter, ContactSort>
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
