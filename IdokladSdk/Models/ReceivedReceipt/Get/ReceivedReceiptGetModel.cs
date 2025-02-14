using IdokladSdk.Models.Contact;
using IdokladSdk.Models.ReceivedReceipt.List;

namespace IdokladSdk.Models.ReceivedReceipt.Get
{
    /// <summary>
    /// ReceivedReceiptGetModel.
    /// </summary>
    public class ReceivedReceiptGetModel : ReceivedReceiptListGetModel
    {
        /// <summary>
        /// Gets or sets contact information of the partner.
        /// </summary>
        public ContactGetModel Partner { get; set; }
    }
}
