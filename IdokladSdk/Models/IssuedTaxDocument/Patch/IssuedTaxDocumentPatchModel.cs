using System;
using System.Collections.Generic;
using IdokladSdk.Models.Base;
using IdokladSdk.Validation.Attributes;

namespace IdokladSdk.Models.IssuedTaxDocument.Patch
{
    /// <summary>
    /// IssuedTaxDocumentPatchModel.
    /// </summary>
    public class IssuedTaxDocumentPatchModel : ValidatableModel, IEntityId
    {
        /// <summary>Gets or sets a value indicating whether this document is an electronic invoice. Available only for Slovak legislation.</summary>
        public bool? IsEInvoice { get; set; }

        /// <summary>
        /// Gets or sets Id.
        /// </summary>
        [RequiredNonDefault]
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets DateOfIssue.
        /// </summary>
        public DateTime? DateOfIssue { get; set; }

        /// <summary>
        /// Gets or sets Items.
        /// </summary>
        public List<IssuedTaxDocumentItemPatchModel> Items { get; set; }
    }
}
