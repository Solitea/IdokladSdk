using System.ComponentModel.DataAnnotations;
using IdokladSdk.Enums;
using IdokladSdk.Models.Base;

namespace IdokladSdk.Models.EInvoiceSettings
{
    /// <summary>
    /// Settings to update a digital access point connection.
    /// </summary>
    public class EInvoiceSettingsPatchModel : ValidatableModel
    {
        /// <summary>Gets or sets the settings identifier.</summary>
        [Required]
        public int Id { get; set; }

        /// <summary>Gets or sets the client identifier.</summary>
        [StringLength(500)]
        public string ClientId { get; set; }

        /// <summary>Gets or sets the client secret.</summary>
        [StringLength(500)]
        public string ClientSecret { get; set; }

        /// <summary>Gets or sets a value indicating whether receiving is enabled.</summary>
        public bool? IsReceivingEnabled { get; set; }

        /// <summary>Gets or sets a value indicating whether sending is enabled.</summary>
        public bool? IsSendingEnabled { get; set; }

        /// <summary>Gets or sets the digital access point type.</summary>
        public AccessPointType? Type { get; set; }
    }
}
