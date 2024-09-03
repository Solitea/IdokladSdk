using System.ComponentModel.DataAnnotations;
using IdokladSdk.Enums;

namespace IdokladSdk.Models.CashVoucher.Pair
{
    /// <summary>
    /// CashVoucherPairPostModel.
    /// </summary>
    public class CashVoucherPairPostModel
    {
        /// <summary>
        /// Gets or sets cash voucher id.
        /// </summary>
        [Required]
        public int CashVoucherId { get; set; }

        /// <summary>
        /// Gets or sets Paired document type.
        /// </summary>
        [Required]
        public PairedDocumentType DocumentType { get; set; }

        /// <summary>
        /// Gets or sets Document Id.
        /// </summary>
        [Required]
        public int DocumentId { get; set; }
    }
}
