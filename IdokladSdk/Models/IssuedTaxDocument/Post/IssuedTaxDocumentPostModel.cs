using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using IdokladSdk.Models.Base;

namespace IdokladSdk.Models.IssuedTaxDocument.Post
{
    /// <summary>
    /// IssuedTaxDocumentPostModel.
    /// </summary>
    public class IssuedTaxDocumentPostModel : ValidatableModel
    {
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
        [Required]
        public int PaymentId { get; set; }
    }
}
