using IdokladSdk.Clients;
using IdokladSdk.Models.Inbox.Get;
using IdokladSdk.Requests.Core;
using IdokladSdk.Requests.Inbox.Filter;
using IdokladSdk.Requests.Inbox.Sort;

namespace IdokladSdk.Requests.Inbox
{
    /// <summary>
    /// Inbox list request.
    /// </summary>
    public class InboxList : BaseList<InboxList, InboxClient, InboxListGetModel, InboxFilter, InboxSort>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="InboxList"/> class.
        /// </summary>
        /// <param name="client">Inbox client.</param>
        public InboxList(InboxClient client)
            : base(client)
        {
        }
    }
}
