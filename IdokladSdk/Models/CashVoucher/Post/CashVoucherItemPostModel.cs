using System.ComponentModel.DataAnnotations;
using IdokladSdk.Enums;
using IdokladSdk.Models.Base;

namespace IdokladSdk.Models.CashVoucher
{
    /// <summary>
    /// Item post model for CashVoucherItem.
    /// </summary>
    public class CashVoucherItemPostModel : ValidatableModel
    {
        /// <summary>
        /// Gets or sets custom VAT rate.
        /// </summary>
        public decimal? CustomVat { get; set; }

        /// <summary>
        /// Gets or sets item name.
        /// </summary>
        [Required]
        [StringLength(200)]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets unit price.
        /// </summary>
        [Required]
        public decimal Price { get; set; }

        /// <summary>
        /// Gets or sets price type.
        /// </summary>
        [Required]
        public PriceTypeWithoutOnlyBase PriceType { get; set; }

        /// <summary>
        /// Gets or sets VAT classification code.
        /// </summary>
        public int? VatCodeId { get; set; }

        /// <summary>
        /// Gets or sets vAT rate type.
        /// </summary>
        [Required]
        public VatRateType VatRateType { get; set; }
    }
}
