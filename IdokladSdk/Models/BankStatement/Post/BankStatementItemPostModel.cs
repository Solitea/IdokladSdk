using System.ComponentModel.DataAnnotations;
using IdokladSdk.Enums;

namespace IdokladSdk.Models.BankStatement.Post
{
    /// <summary>
    /// Item post model for BankStatementItem.
    /// </summary>
    public class BankStatementItemPostModel
    {
        /// <summary>
        /// Gets or sets custom VAT rate.
        /// </summary>
        public decimal? CustomVat { get; set; }

        /// <summary>
        /// Gets or sets Item name.
        /// </summary>
        [StringLength(200)]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets Unit price.
        /// </summary>
        [Required]
        public decimal Price { get; set; }

        /// <summary>
        /// Gets or sets Price type.
        /// </summary>
        [Required]
        public PriceTypeWithoutOnlyBase PriceType { get; set; }

        /// <summary>
        /// Gets or sets VAT classification code.
        /// </summary>
        public int? VatCodeId { get; set; }

        /// <summary>
        /// Gets or sets VAT rate type.
        /// </summary>
        [Required]
        public VatRateType VatRateType { get; set; }
    }
}
