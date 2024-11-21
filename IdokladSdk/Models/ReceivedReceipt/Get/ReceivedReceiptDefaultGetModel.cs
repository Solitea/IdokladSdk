using IdokladSdk.Enums;
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
    }
}
