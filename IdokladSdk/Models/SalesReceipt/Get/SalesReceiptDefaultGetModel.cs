using IdokladSdk.Enums;

namespace IdokladSdk.Models.SalesReceipt
{
    /// <summary>
    /// Default model.
    /// </summary>
    public class SalesReceiptDefaultGetModel : SalesReceiptPostModel
    {
        /// <summary>
        /// Gets or sets Vat regime.
        /// </summary>
        public VatRegime VatRegime { get; set; }
    }
}
