using IdokladSdk.Clients;
using IdokladSdk.Models.Notification.List;
using IdokladSdk.Requests.Core;
using IdokladSdk.Requests.Notification.Filter;
using IdokladSdk.Requests.Notification.Sort;

namespace IdokladSdk.Requests.Notification
{
    /// <summary>
    /// List of notifications.
    /// </summary>
    public class NotificationList : BaseList<NotificationList, NotificationClient, NotificationListGetModel, NotificationFilter, NotificationSort>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="NotificationList"/> class.
        /// </summary>
        /// <param name="client">Contact client.</param>
        public NotificationList(NotificationClient client)
            : base(client)
        {
        }
    }
}
