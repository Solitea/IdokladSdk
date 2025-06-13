using System.ComponentModel.DataAnnotations;
using IdokladSdk.Enums;
using IdokladSdk.Models.Base;
using IdokladSdk.Validation.Attributes;

namespace IdokladSdk.Models.CashVoucher.Pair
{
    /// <summary>
    /// CashVoucherPairPostModel.
    /// </summary>
    public class CashVoucherPairPostModel : ValidatableModel
    {
        /// <summary>
        /// Gets or sets cash voucher id.
        /// </summary>
        [RequiredNonDefault]
        public int CashVoucherId { get; set; }

        /// <summary>
        /// Gets or sets Paired document type.
        /// </summary>
        [Required]
        public PairedDocumentType DocumentType { get; set; }

        /// <summary>
        /// Gets or sets Document Id.
        /// </summary>
        [RequiredNonDefault]
        public int DocumentId { get; set; }
    }
}
