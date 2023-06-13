using System.ComponentModel.DataAnnotations;
using IdokladSdk.Enums;
using IdokladSdk.Models.Common;

namespace IdokladSdk.Models.IssuedDocumentTemplate.Recount
{
    /// <summary>
    /// IssuedDocumentTemplateItemRecountPostModel.
    /// </summary>
    public class IssuedDocumentTemplateItemRecountPostModel : ItemRecountPostModel
    {
        /// <summary>
        /// Gets or sets price type.
        /// </summary>
        [Required]
        public PriceType PriceType { get; set; }
    }
}
