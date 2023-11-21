using IdokladSdk.Enums;

namespace IdokladSdk.Models.CashVoucher
{
    /// <summary>
    /// Default model.
    /// </summary>
    public class CashVoucherDefaultGetModel : CashVoucherPostModel
    {
        /// <summary>
        /// Gets or sets Vat regime.
        /// </summary>
        public VatRegime VatRegime { get; set; }
    }
}
