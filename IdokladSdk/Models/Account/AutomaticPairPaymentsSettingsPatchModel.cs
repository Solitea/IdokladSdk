using IdokladSdk.Models.Base;

namespace IdokladSdk.Models.Account
{
    /// <summary>
    /// AutomaticPairPaymentsSettingsPatchModel.
    /// </summary>
    public class AutomaticPairPaymentsSettingsPatchModel : ValidatableModel
    {
        /// <summary>
        /// Gets or sets a value indicating whether agenda has automatic pair payments.
        /// </summary>
        public bool? HasAutomaticPairPayments { get; set; }
    }
}
