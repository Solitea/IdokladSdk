using IdokladSdk.Models.ReadOnly.Country;

namespace IdokladSdk.Models.ReadOnly.ConstantSymbol
{
    /// <summary>
    /// ConstantSymbolGetModel.
    /// </summary>
    public class ConstantSymbolGetModel : ConstantSymbolListGetModel
    {
        /// <summary>
        /// Gets or sets country.
        /// </summary>
        public CountryGetModel Country { get; set; }
    }
}
