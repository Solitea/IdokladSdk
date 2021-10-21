using System.ComponentModel.DataAnnotations;

namespace IdokladSdk.Models.IssuedTaxDocument.Post
{
    /// <summary>
    /// IssuedTaxDocumentItemPostModel.
    /// </summary>
    public class IssuedTaxDocumentItemPostModel
    {
        /// <summary>
        /// Gets or sets Id entity.
        /// </summary>
        /// <summary xml:lang="en">
        /// The entity's Id
        /// </summary>
        [Required]
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets Item name.
        /// </summary>
        [Required]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets Vat code id.
        /// </summary>
        public int? VatCodeId { get; set; }
    }
}
