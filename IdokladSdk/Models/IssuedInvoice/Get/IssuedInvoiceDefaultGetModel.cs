using IdokladSdk.Enums;

namespace IdokladSdk.Models.IssuedInvoice
{
    /// <summary>
    /// Default model.
    /// </summary>
    public class IssuedInvoiceDefaultGetModel : IssuedInvoicePostModel
    {
        /// <summary>
        /// Gets or sets Vat regime.
        /// </summary>
        public VatRegime VatRegime { get; set; }
    }
}
