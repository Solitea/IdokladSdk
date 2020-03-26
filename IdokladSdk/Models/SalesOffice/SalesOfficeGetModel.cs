using IdokladSdk.Models.ReadOnly.Country;

namespace IdokladSdk.Models.SalesOffice
{
    /// <summary>
    /// SalesOfficeGetModel.
    /// </summary>
    public class SalesOfficeGetModel : SalesOfficeListGetModel
    {
        /// <summary>
        /// Gets or sets country.
        /// </summary>
        public CountryGetModel Country { get; set; }
    }
}
