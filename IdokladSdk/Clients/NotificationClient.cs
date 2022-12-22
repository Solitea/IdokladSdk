using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
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
    public class NotificationClient :
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
        public Task<ApiResult<bool>> DeleteAsync(int id, CancellationToken cancellationToken = default)
        {
            return DeleteAsync<bool>(id, cancellationToken);
        }

        /// <inheritdoc />
        public NotificationList List()
        {
            return new NotificationList(this);
        }

        /// <summary>
        /// Gives count of notifications with status New.
        /// </summary>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns>Count of notifications with status New.</returns>
        public Task<ApiResult<NewNotificationsCountGetModel>> GetNewNotificationCountAsync(CancellationToken cancellationToken = default)
        {
            return GetAsync<NewNotificationsCountGetModel>(ResourceUrl + "/New", null, cancellationToken);
        }

        /// <summary>
        /// Changes status of given notifications.
        /// </summary>
        /// <param name="model">Notification Put Model.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns>Notification Change Status Get Model.</returns>
        public Task<ApiBatchResult<NotificationChangeStatusGetModel>> ChangeStatusAsync(List<NotificationPutModel> model, CancellationToken cancellationToken = default)
        {
            return PutAsync<NotificationPutModel, NotificationChangeStatusGetModel>(ResourceUrl + "/Status", model, cancellationToken);
        }
    }
}
