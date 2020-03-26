using IdokladSdk.Models.Common;

namespace IdokladSdk.Models.SalesOffice
{
    /// <summary>
    /// SalesOfficeListGetModel.
    /// </summary>
    public class SalesOfficeListGetModel : IEntityId
    {
        /// <summary>
        /// Gets or sets city of residence.
        /// </summary>
        public string City { get; set; }

        /// <summary>
        /// Gets or sets country id.
        /// </summary>
        public int CountryId { get; set; }

        /// <summary>
        /// Gets or sets sales office designation.
        /// </summary>
        public int Designation { get; set; }

        /// <inheritdoc/>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether příznak určující jestli je místo zaregistrováno v EET.
        /// </summary>
        /// <summary>
        /// Flag determining whether the point of sale is registered for EET..
        /// </summary>
        public bool IsRegisteredEet { get; set; }

        /// <summary>
        /// Gets or sets additional information about the entity..
        /// </summary>
        public Metadata Metadata { get; set; }

        /// <summary>
        /// Gets or sets sales office name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets area postal code.
        /// </summary>
        public string PostalCode { get; set; }

        /// <summary>
        /// Gets or sets street.
        /// </summary>
        public string Street { get; set; }
    }
}
