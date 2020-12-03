using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using IdokladSdk.Models.Base;
using IdokladSdk.Validation.Attributes;

namespace IdokladSdk.Models.SalesOrder
{
    /// <summary>
    /// SalesOrder Model for Post recount endpoints.
    /// </summary>
    public class SalesOrderRecountPostModel : ValidatableModel
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
        /// Gets or sets invoice items.
        /// </summary>
        [MinCollectionLength(1)]
        [Required]
        public List<SalesOrderItemRecountPostModel> Items { get; set; }

        /// <summary>
        /// Gets or sets date of taxing.
        /// </summary>
        [DateGreaterOrEqualThan(Constants.DefaultDateTimeString)]
        [Required]
        public DateTime DateOfIssue { get; set; }

        /// <summary>
        /// Gets or sets payment option id.
        /// </summary>
        [RequiredNonDefault]
        public int PaymentOptionId { get; set; }
    }
}
