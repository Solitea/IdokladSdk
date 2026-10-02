using IdokladSdk.Enums;
using IdokladSdk.Models.DocumentAddress;

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

        /// <summary>
        /// Gets or sets Partner address.
        /// </summary>
        public DocumentAddressModel PartnerAddress { get; set; }
    }
}
