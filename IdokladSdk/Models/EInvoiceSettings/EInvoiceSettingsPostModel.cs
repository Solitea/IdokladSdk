using System.ComponentModel.DataAnnotations;
using IdokladSdk.Enums;
using IdokladSdk.Models.Base;

namespace IdokladSdk.Models.EInvoiceSettings
{
    /// <summary>
    /// Settings to create a digital access point connection.
    /// </summary>
    public class EInvoiceSettingsPostModel : ValidatableModel
    {
        /// <summary>Gets or sets the client identifier.</summary>
        [Required]
        [StringLength(500)]
        public string ClientId { get; set; }

        /// <summary>Gets or sets the client secret.</summary>
        [Required]
        [StringLength(500)]
        public string ClientSecret { get; set; }

        /// <summary>Gets or sets a value indicating whether receiving is enabled.</summary>
        [Required]
        public bool IsReceivingEnabled { get; set; }

        /// <summary>Gets or sets a value indicating whether sending is enabled.</summary>
        [Required]
        public bool IsSendingEnabled { get; set; }

        /// <summary>Gets or sets the digital access point type.</summary>
        [Required]
        public AccessPointType Type { get; set; }
    }
}
