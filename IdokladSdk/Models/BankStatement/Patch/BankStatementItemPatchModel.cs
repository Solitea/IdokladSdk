using System.ComponentModel.DataAnnotations;
using IdokladSdk.Enums;
using IdokladSdk.Models.Base;
using IdokladSdk.Models.Common;
using IdokladSdk.Validation.Attributes;

namespace IdokladSdk.Models.BankStatement.Patch
{
    /// <summary>
    /// Patch model for BankStatementItem.
    /// </summary>
    public class BankStatementItemPatchModel : ValidatableModel, IEntityId
    {
        /// <summary>
        /// Gets or sets Custom VAT rate.
        /// </summary>
        public NullableProperty<decimal> CustomVat { get; set; }

        /// <summary>
        /// Gets or sets The entity's Id.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets item name.
        /// </summary>
        [StringLength(200)]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets Unit price.
        /// </summary>
        public decimal? Price { get; set; }

        /// <summary>
        /// Gets or sets Price type.
        /// </summary>
        public PriceTypeWithoutOnlyBase? PriceType { get; set; }

        /// <summary>
        /// Gets or sets VAT rate type.
        /// </summary>
        public VatRateType? VatRateType { get; set; }

        /// <summary>
        /// Gets or sets Vat code id.
        /// </summary>
        [NullableForeignKey]
        public NullableProperty<int> VatCodeId { get; set; }
    }
}
