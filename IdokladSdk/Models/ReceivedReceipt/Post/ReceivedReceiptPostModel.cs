using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using IdokladSdk.Validation.Attributes;

namespace IdokladSdk.Models.ReceivedReceipt.Post
{
    /// <summary>
    /// ReceivedReceiptPostModel.
    /// </summary>
    public class ReceivedReceiptPostModel
    {
        /// <summary>
        /// Gets or sets the currency ID.
        /// </summary>
        [RequiredNonDefault]
        public int CurrencyId { get; set; }

        /// <summary>
        /// Gets or sets the date of issue.
        /// </summary>
        public DateTime DateOfIssue { get; set; }

        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        [Required(AllowEmptyStrings = false)]
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the document serial number.
        /// </summary>
        public int DocumentSerialNumber { get; set; }

        /// <summary>
        /// Gets or sets the exchange rate.
        /// </summary>
        public decimal ExchangeRate { get; set; }

        /// <summary>
        /// Gets or sets the exchange rate amount.
        /// </summary>
        public decimal ExchangeRateAmount { get; set; }

        /// <summary>
        /// Gets or sets the external document number.
        /// </summary>
        public string ExternalDocumentNumber { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the document is subject to income tax.
        /// </summary>
        public bool IsIncomeTax { get; set; }

        /// <summary>
        /// Gets or sets the invoice items.
        /// </summary>
        public List<ReceivedReceiptItemPostModel> Items { get; set; }

        /// <summary>
        /// Gets or sets the partner contact ID.
        /// </summary>
        [NullableForeignKey]
        public int? PartnerId { get; set; }

        /// <summary>
        /// Gets or sets the payment option ID.
        /// </summary>
        [RequiredNonDefault]
        public int PaymentOptionId { get; set; }

        /// <summary>
        /// Gets or sets the tags.
        /// </summary>
        public List<int> Tags { get; set; }
    }
}
