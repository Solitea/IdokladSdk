using IdokladSdk.Enums;

namespace IdokladSdk.Models.ProformaInvoice
{
    /// <summary>
    /// Default model.
    /// </summary>
    public class ProformaInvoiceDefaultGetModel : ProformaInvoicePostModel
    {
        /// <summary>
        /// Gets or sets Vat regime.
        /// </summary>
        public VatRegime VatRegime { get; set; }
    }
}
