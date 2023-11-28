using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using IdokladSdk.Models.Base;
using IdokladSdk.Validation.Attributes;

namespace IdokladSdk.Models.RecurringInvoice
{
    /// <summary>
    /// InvoiceTemplateRecountPostModel.
    /// </summary>
    public class InvoiceTemplateRecountPostModel : ValidatableModel
    {
        /// <summary>
        /// Gets or sets currency Id.
        /// </summary>
        [RequiredNonDefault]
        public int CurrencyId { get; set; }

        /// <summary>
        /// Gets or sets date of next issue.
        /// </summary>
        public DateTime? DateOfNextIssue { get; set; }

        /// <summary>
        /// Gets or sets discount size in percent.
        /// </summary>
        [Range(0.0, 99.99)]
        public decimal DiscountPercentage { get; set; }

        /// <summary>
        /// Gets or sets invoice items.
        /// </summary>
        [MinCollectionLength(1)]
        [Required]
        public List<InvoiceItemTemplateRecountPostModel> Items { get; set; }

        /// <summary>
        /// Gets or sets payment option Id.
        /// </summary>
        [RequiredNonDefault]
        public int PaymentOptionId { get; set; }
    }
}
