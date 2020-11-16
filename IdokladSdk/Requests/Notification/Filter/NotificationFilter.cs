using System;
using IdokladSdk.Enums;
using IdokladSdk.Models.Notification.List;
using IdokladSdk.Requests.Core.Modifiers.Filters;
using IdokladSdk.Requests.Core.Modifiers.Filters.Common;

namespace IdokladSdk.Requests.Notification.Filter
{
    /// <summary>
    /// Filterable properties of <see cref="NotificationListGetModel"/>.
    /// </summary>
    public class NotificationFilter : IdFilter
    {
        /// <inheritdoc cref="NotificationListGetModel.DateCreated"/>
        public CompareFilterItem<DateTime> DateCreated { get; set; } = new CompareFilterItem<DateTime>(nameof(NotificationListGetModel.DateCreated));

        /// <inheritdoc cref="NotificationListGetModel.Status"/>
        public FilterItem<NotificationUserStatus> Status { get; set; } = new FilterItem<NotificationUserStatus>(nameof(NotificationListGetModel.Status));

        /// <inheritdoc cref="NotificationListGetModel.Type"/>
        public FilterItem<NotificationType> Type { get; set; } = new FilterItem<NotificationType>(nameof(NotificationListGetModel.Type));
    }
}
