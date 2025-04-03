using System;
using IdokladSdk.Enums;

namespace IdokladSdk.Models.Webhook
{
    /// <summary>
    /// Model for Get endpoints.
    /// </summary>
    public class AgendaWebhookSettingsGetModel
    {
        /// <summary>
        /// Gets or sets type of actions for which the webhook should be called.
        /// </summary>
        public WebhookActionType ActionType { get; set; }

        /// <summary>
        /// Gets or sets public id of the webhook from the Developer portal.
        /// </summary>
        public Guid PublicId { get; set; }

        /// <summary>
        /// Gets or sets type of entity to which the webhook is attached.
        /// </summary>
        public WebhookEntityType EntityType { get; set; }

        /// <summary>
        /// Gets or sets entity id.
        /// </summary>
        public int Id { get; set; }
    }
}
