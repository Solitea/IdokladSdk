using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using IdokladSdk.Validation.Attributes;

namespace IdokladSdk.Models.ReceivedReceipt.Post
{
    /// <summary>
    /// ReceivedReceiptRecountPostModel.
    /// </summary>
    public class ReceivedReceiptRecountPostModel
    {
        /// <summary>
        /// Gets or sets the currency ID.
        /// </summary>
        public int CurrencyId { get; set; }

        /// <summary>
        /// Gets or sets the date of issue.
        /// </summary>
        [Required]
        [DateGreaterOrEqualThan(Constants.DefaultDateTimeString, true)]
        public DateTime DateOfIssue { get; set; }

        /// <summary>
        /// Gets or sets the exchange rate.
        /// </summary>
        public decimal ExchangeRate { get; set; }

        /// <summary>
        /// Gets or sets the exchange rate amount.
        /// </summary>
        public decimal ExchangeRateAmount { get; set; }

        /// <summary>
        /// Gets or sets the list of invoice items.
        /// </summary>
        [MinCollectionLength(1)]
        [Required]
        public List<ReceivedReceiptItemRecountPostModel> Items { get; set; }
    }
}
