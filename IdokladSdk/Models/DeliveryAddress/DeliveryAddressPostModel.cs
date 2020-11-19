using System.ComponentModel.DataAnnotations;

namespace IdokladSdk.Models.DeliveryAddress
{
    /// <summary>
    /// DeliveryAddressPostModel.
    /// </summary>
    public class DeliveryAddressPostModel
    {
        /// <summary>
        /// Gets or sets city of residence.
        /// </summary>
        public string City { get; set; }

        /// <summary>
        /// Gets or sets name of delivery address.
        /// </summary>
        [Required]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether delivery address is default.
        /// </summary>
        public bool IsDefault { get; set; }

        /// <summary>
        /// Gets or sets postal code.
        /// </summary>
        public string PostalCode { get; set; }

        /// <summary>
        /// Gets or sets street.
        /// </summary>
        public string Street { get; set; }
    }
}
