using System.ComponentModel.DataAnnotations;
using IdokladSdk.Enums;
using IdokladSdk.Models.Base;

namespace IdokladSdk.Models.BankStatement.Recount
{
    /// <summary>
    /// BankStatementItemRecountPostModel.
    /// </summary>
    public class BankStatementItemRecountPostModel : ValidatableModel, IEntityId
    {
        /// <summary>
        /// Gets or sets Custom VAT rate.
        /// </summary>
        public decimal? CustomVat { get; set; }

        /// <summary>
        /// Gets or sets price type.
        /// </summary>
        [Required]
        public PriceType? PriceType { get; set; }

        /// <summary>
        /// Gets or sets Id.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets item name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets unit price.
        /// </summary>
        [Required]
        public decimal? UnitPrice { get; set; }

        /// <summary>
        /// Gets or sets VAT rate type.
        /// </summary>
        [Required]
        public VatRateType? VatRateType { get; set; }
    }
}
