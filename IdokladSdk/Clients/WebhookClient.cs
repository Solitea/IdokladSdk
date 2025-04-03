using System.Threading;
using System.Threading.Tasks;
using IdokladSdk.Clients.Interfaces;
using IdokladSdk.Models.Webhook;
using IdokladSdk.Requests.Webhook;
using IdokladSdk.Response;

namespace IdokladSdk.Clients
{
    /// <summary>
    /// Webhook client.
    /// </summary>
    public class WebhookClient :
        BaseClient,
        IDeleteRequest,
        IPostRequest<AgendaWebhookSettingsPostModel, AgendaWebhookSettingsGetModel>,
        IEntityDetail<WebhookDetail>,
        IEntityList<WebhookList>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="WebhookClient" /> class.
        /// </summary>
        /// <param name="apiContext">API context.</param>
        public WebhookClient(ApiContext apiContext)
            : base(apiContext)
        {
        }

        /// <inheritdoc />
        public override string ResourceUrl { get; } = "/Webhooks";

        /// <inheritdoc />
        public WebhookDetail Detail(int id)
        {
            return new WebhookDetail(id, this);
        }

        /// <inheritdoc />
        public WebhookList List()
        {
            return new WebhookList(this);
        }

        /// <inheritdoc />
        public Task<ApiResult<AgendaWebhookSettingsGetModel>> PostAsync(
            AgendaWebhookSettingsPostModel model,
            CancellationToken cancellationToken = default)
        {
            return PostAsync<AgendaWebhookSettingsPostModel, AgendaWebhookSettingsGetModel>(
                model,
                cancellationToken);
        }

        /// <inheritdoc/>
        public Task<ApiResult<bool>> DeleteAsync(int id, CancellationToken cancellationToken = default)
        {
            return DeleteAsync<bool>(id, cancellationToken);
        }
    }
}
