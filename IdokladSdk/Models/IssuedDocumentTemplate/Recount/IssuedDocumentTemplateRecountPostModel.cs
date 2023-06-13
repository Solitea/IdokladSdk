using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using IdokladSdk.Validation.Attributes;

namespace IdokladSdk.Models.IssuedDocumentTemplate.Recount
{
    /// <summary>
    /// IssuedDocumentTemplateRecountPostModel.
    /// </summary>
    public class IssuedDocumentTemplateRecountPostModel
    {
        /// <summary>
        /// Gets or sets currency id.
        /// </summary>
        public int CurrencyId { get; set; }

        /// <summary>
        /// Gets or sets discount percentage.
        /// </summary>
        [Range(0.0, 99.99)]
        public decimal DiscountPercentage { get; set; }

        /// <summary>
        /// Gets or sets items.
        /// </summary>
        [MinCollectionLength(1)]
        [Required]
        public List<IssuedDocumentTemplateItemRecountPostModel> Items { get; set; }

        /// <summary>
        /// Gets or sets payment options id.
        /// </summary>
        public int PaymentOptionId { get; set; }
    }
}
