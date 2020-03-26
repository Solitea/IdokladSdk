using IdokladSdk.Clients;
using IdokladSdk.Models.Contact;
using IdokladSdk.Requests.Core;
using IdokladSdk.Requests.Core.Modifiers.Expand.Structure;

namespace IdokladSdk.Requests.Contact
{
    /// <summary>
    /// Detail of contact.
    /// </summary>
    public class ContactDetail : ExpandableDetail<ContactDetail, ContactClient, ContactGetModel, ContactExpand>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ContactDetail"/> class.
        /// </summary>
        /// <param name="id">Contact id.</param>
        /// <param name="client">Contact client.</param>
        public ContactDetail(int id, ContactClient client)
            : base(id, client)
        {
        }
    }
}
