using IdokladSdk.Clients.Interfaces;
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
    }
}
