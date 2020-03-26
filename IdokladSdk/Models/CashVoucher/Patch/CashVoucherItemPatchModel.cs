using IdokladSdk.Enums;
using IdokladSdk.Validation.Attributes;

namespace IdokladSdk.Models.CashVoucher
{
    /// <summary>
    /// Pathc model for CashVoucherItem.
    /// </summary>
    public class CashVoucherItemPatchModel
    {
        /// <summary>
        /// Gets or sets item amount.
        /// </summary>
        public decimal? Amount { get; set; }

        /// <summary>
        /// Gets or sets item name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets unit price.
        /// </summary>
        [DecimalGreaterThanZero]
        public decimal? Price { get; set; }

        /// <summary>
        /// Gets or sets price type.
        /// </summary>
        public PriceTypeWithoutOnlyBase? PriceType { get; set; }

        /// <summary>
        /// Gets or sets pairing status.
        /// </summary>
        public PairingStatus? Status { get; set; }

        /// <summary>
        /// Gets or sets VAT rate type.
        /// </summary>
        public VatRateType? VatRateType { get; set; }
    }
}
