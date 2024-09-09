using System.ComponentModel.DataAnnotations;
using IdokladSdk.Enums;
using IdokladSdk.Models.Base;
using IdokladSdk.Validation.Attributes;

namespace IdokladSdk.Models.CashVoucher
{
    /// <summary>
    /// Patch model for CashVoucherItem.
    /// </summary>
    public class CashVoucherItemPatchModel : ValidatableModel, IEntityId
    {
        /// <summary>
        /// Gets or sets Custom VAT rate.
        /// </summary>
        public decimal? CustomVat { get; set; }

        /// <summary>
        /// Gets or sets The entity's Id.
        /// </summary>
        [Required]
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets item name.
        /// </summary>
        [StringLength(200)]
        [NotEmptyString]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets unit price.
        /// </summary>
        public decimal? Price { get; set; }

        /// <summary>
        /// Gets or sets price type.
        /// </summary>
        public PriceTypeWithoutOnlyBase? PriceType { get; set; }

        /// <summary>
        /// Gets or sets Vat code id.
        /// </summary>
        public int? VatCodeId { get; set; }

        /// <summary>
        /// Gets or sets VAT rate type.
        /// </summary>
        public VatRateType? VatRateType { get; set; }
    }
}
