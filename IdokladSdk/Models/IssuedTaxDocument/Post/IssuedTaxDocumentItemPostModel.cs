using System.ComponentModel.DataAnnotations;
using IdokladSdk.Enums;

namespace IdokladSdk.Models.IssuedTaxDocument.Post
{
    /// <summary>
    /// IssuedTaxDocumentItemPostModel.
    /// </summary>
    public class IssuedTaxDocumentItemPostModel
    {
        /// <summary>
        /// Gets or sets Item name.
        /// </summary>
        [Required]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets Price type.
        /// </summary>
        [Required]
        public PriceType PriceType { get; set; }

        /// <summary>
        /// Gets or sets Vat code id.
        /// </summary>
        public int? VatCodeId { get; set; }

        /// <summary>
        /// Gets or sets VAT rate in percent.
        /// </summary>
        [Required]
        public decimal VatRate { get; set; }
    }
}
