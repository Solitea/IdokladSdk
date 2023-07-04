using System.ComponentModel.DataAnnotations;
using Doklad.Shared.Enums.Api;
using IdokladSdk.Enums;
using IdokladSdk.Models.Base;

namespace IdokladSdk.Models.IssuedDocumentTemplate.Post
{
    /// <summary>
    /// IssuedDocumentTemplateItemPostModel.
    /// </summary>
    public class IssuedDocumentTemplateItemPostModel : ValidatableModel
    {
        /// <summary>
        /// Gets or sets item amount.
        /// </summary>
        [Required]
        public decimal Amount { get; set; }

        /// <summary>
        /// Gets or sets item type.
        /// </summary>
        public PostIssuedDocumentTemplateItemType ItemType { get; set; }

        /// <summary>
        /// Gets or sets item name.
        /// </summary>
        [Required(AllowEmptyStrings = true)]
        [StringLength(200)]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets price list item Id.
        /// </summary>
        public int? PriceListItemId { get; set; }

        /// <summary>
        /// Gets or sets price type.
        /// </summary>
        [Required]
        public PriceType PriceType { get; set; }

        /// <summary>
        /// Gets or sets unit of measure.
        /// </summary>
        [StringLength(20)]
        public string Unit { get; set; }

        /// <summary>
        /// Gets or sets unit of measure.
        /// </summary>
        [Required]
        public decimal UnitPrice { get; set; }

        /// <summary>
        /// Gets or sets VAT rate in percent.
        /// </summary>
        public int? VatCodeId { get; set; }

        /// <summary>
        /// Gets or sets VAT rate type.
        /// </summary>
        [Required]
        public VatRateType VatRateType { get; set; }
    }
}
