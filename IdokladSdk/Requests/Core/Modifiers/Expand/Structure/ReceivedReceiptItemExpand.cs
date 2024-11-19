using IdokladSdk.Models.ReadOnly.VatCode;

namespace IdokladSdk.Requests.Core.Modifiers.Expand.Structure
{
    /// <summary>
    /// ReceivedReceiptItemExpand.
    /// </summary>
    public class ReceivedReceiptItemExpand
    {
        /// <summary>
        /// Gets or sets the associated vat code ID.
        /// </summary>
        public VatCodeGetModel VatCode { get; set; }
    }
}
