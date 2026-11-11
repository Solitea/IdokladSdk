using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using IdokladSdk.Models.Base;
using IdokladSdk.Validation.Attributes;

namespace IdokladSdk.Models.IssuedTaxDocument.Post
{
    /// <summary>
    /// IssuedTaxDocumentPostModel.
    /// </summary>
    public class IssuedTaxDocumentPostModel : ValidatableModel
    {
        /// <summary>Gets or sets a value indicating whether to create an electronic invoice. Available only for Slovak legislation.</summary>
        public bool? IsEInvoice { get; set; }

        /// <summary>
        /// Gets or sets Date of issue.
        /// </summary>
        [Required]
        public DateTime DateOfIssue { get; set; }

        /// <summary>
        /// Gets or sets Tax document items.
        /// </summary>
        [Required]
        public List<IssuedTaxDocumentItemPostModel> Items { get; set; }

        /// <summary>
        /// Gets or sets Id of payment.
        /// </summary>
        [RequiredIf(nameof(CorrectedDocumentId), null)]
        public int? PaymentId { get; set; }

        /// <summary>Gets or sets the ID of the corrected tax document. Required when PaymentId is omitted.</summary>
        [RequiredIf(nameof(PaymentId), null)]
        [Range(1, int.MaxValue)]
        public int? CorrectedDocumentId { get; set; }
    }
}
