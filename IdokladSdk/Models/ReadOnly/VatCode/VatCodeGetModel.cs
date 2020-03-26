using IdokladSdk.Models.ReadOnly.Country;

namespace IdokladSdk.Models.ReadOnly.VatCode
{
    /// <summary>
    /// VatCodeGetModel.
    /// </summary>
    public class VatCodeGetModel : VatCodeListGetModel
    {
        /// <summary>
        /// Gets or sets country.
        /// </summary>
        public CountryGetModel Country { get; set; }
    }
}
