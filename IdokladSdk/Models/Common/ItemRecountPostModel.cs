using System.ComponentModel.DataAnnotations;
using IdokladSdk.Enums;

namespace IdokladSdk.Models.Common
{
    /// <summary>
    /// ItemRecountPostModel.
    /// </summary>
    public class ItemRecountPostModel : IEntityId
    {
        /// <summary>
        /// Gets or sets item amount.
        /// </summary>
        [Required]
        public decimal? Amount { get; set; }

        /// <inheritdoc/>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets item name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets price type.
        /// </summary>
        [Required]
        public PriceType? PriceType { get; set; }

        /// <summary>
        /// Gets or sets unit price.
        /// </summary>
        [Required]
        public decimal? UnitPrice { get; set; }

        /// <summary>
        /// Gets or sets vAT rate type.
        /// </summary>
        [Required]
        public VatRateType? VatRateType { get; set; }
    }
}
