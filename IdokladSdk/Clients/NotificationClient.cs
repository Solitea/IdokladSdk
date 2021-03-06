﻿using System.Collections.Generic;
using IdokladSdk.Clients.Interfaces;
using IdokladSdk.Models.Notification.Get;
using IdokladSdk.Models.Notification.Put;
using IdokladSdk.Requests.Notification;
using IdokladSdk.Response;

namespace IdokladSdk.Clients
{
    /// <summary>
    /// Client for communication with notification endpoints.
    /// </summary>
    public partial class NotificationClient :
        BaseClient,
        IEntityList<NotificationList>,
        IDeleteRequest
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="NotificationClient"/> class.
        /// </summary>
        /// <param name="apiContext">API context.</param>
        public NotificationClient(ApiContext apiContext)
            : base(apiContext)
        {
        }

        /// <inheritdoc />
        public override string ResourceUrl { get; } = "/Notifications";

        /// <inheritdoc />
        public ApiResult<bool> Delete(int id)
        {
            return Delete<bool>(id);
        }

        /// <inheritdoc />
        public NotificationList List()
        {
            return new NotificationList(this);
        }

        /// <summary>
        /// Gives count of notifications with status New.
        /// </summary>
        /// <returns>Count of notifications with status New.</returns>
        public ApiResult<NewNotificationsCountGetModel> GetNewNotificationCount()
        {
            return Get<NewNotificationsCountGetModel>(ResourceUrl + "/New");
        }

        /// <summary>
        /// Changes status of given notifications.
        /// </summary>
        /// <param name="model">Notification Put Model.</param>
        /// <returns>Notification Change Status Get Model.</returns>
        public ApiBatchResult<NotificationChangeStatusGetModel> ChangeStatus(List<NotificationPutModel> model)
        {
            return Put<NotificationPutModel, NotificationChangeStatusGetModel>(ResourceUrl + "/Status", model);
        }
    }
}
