using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace IdokladSdk.Models.Email
{
    /// <summary>
    /// Settings for sending email with SalesOrder.
    /// </summary>
    public class SalesOrderEmailSettings : EmailSettings
    {
        /// <summary>
        /// Gets or sets a value indicating whether an email will be sent to the partner (purchaser/supplier) specified on the document.
        /// </summary>
        [Required]
        public bool SendToPartner { get; set; }

        /// <inheritdoc/>
        public override bool HasRecipients() => SendToPartner || OtherRecipients.Any();
    }
}
