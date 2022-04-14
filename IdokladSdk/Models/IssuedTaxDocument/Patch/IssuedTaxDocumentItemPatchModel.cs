using System.ComponentModel.DataAnnotations;
using IdokladSdk.Models.Base;
using IdokladSdk.Validation.Attributes;

namespace IdokladSdk.Models.IssuedTaxDocument.Patch
{
    /// <summary>
    /// IssuedTaxDocumentItemPatchModel.
    /// </summary>
    public class IssuedTaxDocumentItemPatchModel : ValidatableModel, IEntityId
    {
        /// <summary>
        /// Gets or sets Id.
        /// </summary>
        [RequiredNonDefault]
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets Name.
        /// </summary>
        [StringLength(200)]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets VatCodeId.
        /// </summary>
        [NullableForeignKey]
        public int? VatCodeId { get; set; }
    }
}
