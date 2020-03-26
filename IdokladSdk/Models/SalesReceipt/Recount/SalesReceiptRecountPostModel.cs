using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using IdokladSdk.Validation.Attributes;

namespace IdokladSdk.Models.SalesReceipt
{
    /// <summary>
    /// SalesReceipt Model for Post recount endpoints.
    /// </summary>
    public class SalesReceiptRecountPostModel
    {
        /// <summary>
        /// Gets or sets currency id.
        /// </summary>
        [RequiredNonDefault]
        public int CurrencyId { get; set; }

        /// <summary>
        /// Gets or sets exchange rate.
        /// </summary>
        public decimal ExchangeRate { get; set; }

        /// <summary>
        /// Gets or sets exchange rate amount.
        /// </summary>
        public decimal ExchangeRateAmount { get; set; }

        /// <summary>
        /// Gets or sets Items.
        /// </summary>
        [MinCollectionLength(1)]
        [Required]
        public List<SalesReceiptItemRecountPostModel> Items { get; set; }

        /// <summary>
        /// Gets or sets Date of issue.
        /// </summary>
        [DateGreaterOrEqualThan(Constants.DefaultDateTimeString)]
        [Required]
        public DateTime DateOfIssue { get; set; }

        /// <summary>
        /// Gets or sets Payments.
        /// </summary>
        [CollectionRange(1, 2)]
        [Required]
        public List<SalesReceiptPaymentRecountPostModel> Payments { get; set; }
    }
}
