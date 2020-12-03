using System.ComponentModel.DataAnnotations;
using IdokladSdk.Models.Base;

namespace IdokladSdk.Models.DeliveryAddress
{
    /// <summary>
    /// DeliveryAddressPatchModel.
    /// </summary>
    public class DeliveryAddressPatchModel : ValidatableModel, IEntityId
    {
        /// <summary>
        /// Gets or sets city of residence.
        /// </summary>
        public string City { get; set; }

        /// <summary>
        /// Gets or sets name of delivery address.
        /// </summary>
        public string Name { get; set; }

        /// <inheritdoc />
        [Required]
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether delivery address is default.
        /// </summary>
        public bool? IsDefault { get; set; }

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
