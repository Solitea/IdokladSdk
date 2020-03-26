using System.ComponentModel.DataAnnotations;
using IdokladSdk.Enums;
using IdokladSdk.Validation.Attributes;

namespace IdokladSdk.Models.CashVoucher
{
    /// <summary>
    /// Item post model for CashVoucherItem.
    /// </summary>
    public class CashVoucherItemPostModel
    {
        /// <summary>
        /// Gets or sets custom VAT rate.
        /// </summary>
        public decimal? CustomVatRate { get; set; }

        /// <summary>
        /// Gets or sets item name.
        /// </summary>
        [Required]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets unit price.
        /// </summary>
        [Required]
        [DecimalGreaterThanZero]
        public decimal Price { get; set; }

        /// <summary>
        /// Gets or sets price type.
        /// </summary>
        public PriceTypeWithoutOnlyBase PriceType { get; set; }

        /// <summary>
        /// Gets or sets vAT rate type.
        /// </summary>
        public VatRateType VatRateType { get; set; }
    }
}
