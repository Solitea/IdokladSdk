using IdokladSdk.Models.Notification.List;
using IdokladSdk.Requests.Core.Modifiers.Sort.Common;

namespace IdokladSdk.Requests.Notification.Sort
{
    /// <summary>
    /// Sortable properties of <see cref="NotificationListGetModel"/>.
    /// </summary>
    public class NotificationSort
    {
        /// <inheritdoc cref="NotificationListGetModel.DateCreated"/>
        public SortItem DateCreated { get; set; } = new SortItem(nameof(NotificationListGetModel.DateCreated));
    }
}
