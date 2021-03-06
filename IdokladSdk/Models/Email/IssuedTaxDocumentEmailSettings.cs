﻿using System.ComponentModel.DataAnnotations;
using System.Linq;
using IdokladSdk.Enums;
using Newtonsoft.Json;

namespace IdokladSdk.Models.Email
{
    /// <summary>
    /// IssuedTaxDocumentEmailSettings.
    /// </summary>
    public class IssuedTaxDocumentEmailSettings : EmailSettings
    {
        /// <summary>
        /// Gets or sets a value indicating whether an email will be sent to acountant.
        /// The accountant's E-mail and mail template are specified in the application settings.
        /// </summary>
        [Required]
        public bool SendToAccountant { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether a copy of the e-mail will be sent to your company address.
        /// </summary>
        [Required]
        public bool SendToSelf { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether an email will be sent to the partner (purchaser/supplier) specified on the document.
        /// </summary>
        [Required]
        public bool SendToPartner { get; set; }

        /// <inheritdoc/>
        public override bool HasRecipients() => SendToAccountant || SendToPartner || SendToSelf || OtherRecipients.Any();
    }
}
