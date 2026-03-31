using IdokladSdk.Clients;
using IdokladSdk.Models.Inbox.Get;
using IdokladSdk.Requests.Core;

namespace IdokladSdk.Requests.Inbox
{
    /// <summary>
    /// Inbox detail request.
    /// </summary>
    public class InboxDetail : EntityDetail<InboxDetail, InboxClient, InboxDetailGetModel>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="InboxDetail"/> class.
        /// </summary>
        /// <param name="id">Inbox item id.</param>
        /// <param name="client">Inbox client.</param>
        public InboxDetail(int id, InboxClient client)
            : base(id, client)
        {
        }
    }
}
