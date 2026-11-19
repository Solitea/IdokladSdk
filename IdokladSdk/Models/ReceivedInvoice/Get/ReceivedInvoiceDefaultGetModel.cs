using IdokladSdk.Enums;
using IdokladSdk.Models.DocumentAddress;

namespace IdokladSdk.Models.ReceivedInvoice
{
    /// <summary>
    /// Default model.
    /// </summary>
    public class ReceivedInvoiceDefaultGetModel : ReceivedInvoicePostModel
    {
        /// <summary>Gets or sets a value indicating whether the document is an electronic invoice. Available for Slovak legislation.</summary>
        public bool IsEInvoice { get; set; }

        /// <summary>Gets or sets the electronic invoice channel. Available for Slovak legislation.</summary>
        public EInvoiceChannel EInvoiceChannel { get; set; }

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
