using IdokladSdk.Enums;
using IdokladSdk.Models.Base;
using IdokladSdk.Models.Common;

namespace IdokladSdk.Models.Account
{
    /// <summary>
    /// PurchaseSettingsPatchModel.
    /// </summary>
    public class PurchaseSettingsPatchModel : ValidatableModel
    {
        /// <summary>
        /// Gets or sets default price type.
        /// </summary>
        public PriceType? DefaultPriceType { get; set; }

        /// <summary>
        /// Gets or sets default VAT code ID.
        /// </summary>
        public NullableProperty<int> DefaultVatCodeId { get; set; }

        /// <summary>
        /// Gets or sets default VAT rate.
        /// </summary>
        public VatRateType? DefaultVatRate { get; set; }
    }
}
