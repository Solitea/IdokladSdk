using IdokladSdk.Enums;

namespace IdokladSdk.Models.EInvoiceSettings
{
    /// <summary>
    /// Electronic invoice settings for a digital access point.
    /// </summary>
    public class EInvoiceSettingsGetModel
    {
        /// <summary>Gets or sets the settings identifier.</summary>
        public int Id { get; set; }

        /// <summary>Gets or sets the name of the digital access point.</summary>
        public string PostmanName { get; set; }

        /// <summary>Gets or sets the digital access point type.</summary>
        public AccessPointType Type { get; set; }

        /// <summary>Gets or sets the client identifier.</summary>
        public string ClientId { get; set; }

        /// <summary>Gets or sets a value indicating whether the settings are active.</summary>
        public bool IsActive { get; set; }

        /// <summary>Gets or sets a value indicating whether sending is enabled.</summary>
        public bool IsSendingEnabled { get; set; }

        /// <summary>Gets or sets a value indicating whether receiving is enabled.</summary>
        public bool IsReceivingEnabled { get; set; }
    }
}
