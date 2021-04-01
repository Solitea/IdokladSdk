using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using IdokladSdk.Models.Notification.Get;
using IdokladSdk.Models.Notification.Put;
using IdokladSdk.Response;

namespace IdokladSdk.Clients
{
    public partial class NotificationClient
    {
        /// <inheritdoc />
        public Task<ApiResult<bool>> DeleteAsync(int id, CancellationToken cancellationToken = default)
        {
            return DeleteAsync<bool>(id, cancellationToken);
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
