using IdokladSdk.Clients;
using IdokladSdk.Models.Webhook;
using IdokladSdk.Requests.Core;
using IdokladSdk.Requests.Core.Modifiers.Filters;
using IdokladSdk.Requests.Core.Modifiers.Sort.BasicSorts;

namespace IdokladSdk.Requests.Webhook
{
    /// <summary>
    /// WebhookList.
    /// </summary>
    public class WebhookList : BaseList<WebhookList, WebhookClient, AgendaWebhookSettingsGetModel, IdFilter, IdSort>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="WebhookList"/> class.
        /// </summary>
        /// <param name="client">Webhook list client.</param>
        public WebhookList(WebhookClient client)
            : base(client)
        {
        }
    }
}
