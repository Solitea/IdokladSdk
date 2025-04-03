using IdokladSdk.Clients;
using IdokladSdk.Models.Webhook;
using IdokladSdk.Requests.Core;

namespace IdokladSdk.Requests.Webhook
{
    /// <summary>
    /// Webhook detail.
    /// </summary>
    public class WebhookDetail
        : EntityDetail<WebhookDetail, WebhookClient, AgendaWebhookSettingsGetModel>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="WebhookDetail"/> class.
        /// </summary>
        /// <param name="id">Id.</param>
        /// <param name="client">Webhook client.</param>
        public WebhookDetail(int id, WebhookClient client)
            : base(id, client)
        {
        }
    }
}
