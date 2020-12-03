using System.ComponentModel.DataAnnotations;
using IdokladSdk.Models.Base;

namespace IdokladSdk.Models.DeliveryAddress
{
    /// <summary>
    /// DeliveryAddressPostModel.
    /// </summary>
    public class DeliveryAddressPostModel : ValidatableModel
    {
        /// <summary>
        /// Gets or sets city of residence.
        /// </summary>
        [StringLength(50)]
        public string City { get; set; }

        /// <summary>
        /// Gets or sets name of delivery address.
        /// </summary>
        [Required]
        [StringLength(200)]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether delivery address is default.
        /// </summary>
        public bool IsDefault { get; set; }

        /// <summary>
        /// Gets or sets postal code.
        /// </summary>
        [StringLength(11)]
        public string PostalCode { get; set; }

        /// <summary>
        /// Gets or sets street.
        /// </summary>
        [StringLength(100)]
        public string Street { get; set; }
    }
}
