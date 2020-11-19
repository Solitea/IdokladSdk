namespace IdokladSdk.Models.DeliveryAddress
{
    /// <summary>
    /// DeliveryAddressGetModel.
    /// </summary>
    public class DeliveryAddressGetModel : IEntityId
    {
        /// <summary>
        /// Gets or sets city of residence.
        /// </summary>
        public string City { get; set; }

        /// <summary>
        /// Gets or sets name of delivery address.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets country Id.
        /// </summary>
        public int CountryId { get; set; }

        /// <inheritdoc />
        public int Id { get; set; }

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
