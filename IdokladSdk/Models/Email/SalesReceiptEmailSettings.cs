using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using IdokladSdk.Enums;
using Newtonsoft.Json;

namespace IdokladSdk.Models.Email
{
    /// <summary>
    /// Settings for sending email with ReceivedInvoice.
    /// </summary>
    public class SalesReceiptEmailSettings : EmailSettings
    {
        /// <summary>
        /// Gets or sets a value indicating whether an email will be sent to accountant.
        /// The accountant's E-mail and mail template are specified in the application settings.
        /// </summary>
        [Required]
        public bool SendToAccountant { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether an email will be sent to the partner (purchaser/supplier) specified on the
        /// document.
        /// </summary>
        [Required]
        public bool SendToPartner { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether a copy of the e-mail will be sent to your company address.
        /// </summary>
        [Required]
        public bool SendToSelf { get; set; }

        /// <summary>
        /// Gets or sets send type - pdf attachment or sales receipt link.
        /// If not set, the value from your settings will be used.
        /// </summary>
        [JsonProperty("Method")]
        public SendType? SendType { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether include the document's attachment if it has one.
        /// Default is <c>false</c>.
        /// </summary>
        [Obsolete("Sales receipt don't send attachment", true)]
        public new bool SendAttachment
        {
            get => false;
            set => throw new NotImplementedException();
        }

        /// <inheritdoc />
        public override bool HasRecipients() =>
            SendToAccountant || SendToPartner || SendToSelf || OtherRecipients.Any();
    }
}
