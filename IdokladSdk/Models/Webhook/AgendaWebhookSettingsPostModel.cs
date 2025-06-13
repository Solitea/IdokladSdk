using System;
using System.ComponentModel.DataAnnotations;
using IdokladSdk.Enums;
using IdokladSdk.Models.Base;

namespace IdokladSdk.Models.Webhook
{
    /// <summary>
    /// AgendaWebhookSettingsPostModel.
    /// </summary>
    public class AgendaWebhookSettingsPostModel : ValidatableModel
    {
        /// <summary>
        /// Gets or sets type of actions for which the webhook should be called.
        /// </summary>
        [Required]
        public WebhookActionType ActionType { get; set; }

        /// <summary>
        /// Gets or sets type of entity to which the webhook is attached.
        /// </summary>
        [Required]
        public WebhookEntityType EntityType { get; set; }

        /// <summary>
        /// Gets or sets public id of the webhook from the Developer portal.
        /// </summary>
        [Required]
        public Guid PublicId { get; set; }
    }
}
