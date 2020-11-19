namespace IdokladSdk.Models.DeliveryAddress
{
    /// <summary>
    /// DeliveryDocumentAddressGetModel.
    /// </summary>
    public class DeliveryDocumentAddressGetModel
    {
        /// <summary>
        /// Gets or sets contact delivery address Id.
        /// </summary>
        public int? ContactDeliveryAddressId { get; set; }

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
