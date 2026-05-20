using IdokladSdk.Enums;
using IdokladSdk.Models.Contact;
using IdokladSdk.Models.ReceivedReceipt.Post;

namespace IdokladSdk.Models.ReceivedReceipt.Get
{
    /// <summary>
    /// ReceivedReceiptDefaultGetModel.
    /// </summary>
    public class ReceivedReceiptDefaultGetModel : ReceivedReceiptPostModel
    {
        /// <summary>
        /// Gets or sets Vat regime.
        /// </summary>
        public VatRegime VatRegime { get; set; }

        /// <summary>
        /// Gets or sets Partner.
        /// </summary>
        public ContactGetModel Partner { get; set; }
    }
}
