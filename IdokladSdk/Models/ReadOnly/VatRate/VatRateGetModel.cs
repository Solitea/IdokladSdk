using IdokladSdk.Models.ReadOnly.Country;

namespace IdokladSdk.Models.ReadOnly.VatRate
{
    /// <summary>
    /// VatRateGetModel.
    /// </summary>
    public class VatRateGetModel : VatRateListGetModel
    {
        /// <summary>
        /// Gets or sets country.
        /// </summary>
        public CountryGetModel Country { get; set; }
    }
}
