using IdokladSdk.Enums;

namespace IdokladSdk.Models.ReceivedInvoice
{
    /// <summary>
    /// Default model.
    /// </summary>
    public class ReceivedInvoiceDefaultGetModel : ReceivedInvoicePostModel
    {
        /// <summary>
        /// Gets or sets Vat regime.
        /// </summary>
        public VatRegime VatRegime { get; set; }
    }
}
