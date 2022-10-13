using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using IdokladSdk.Models.Base;
using IdokladSdk.Validation.Attributes;

namespace IdokladSdk.Models.ReceivedInvoice
{
    /// <summary>
    /// ReceivedInvoiceRecountPostModel.
    /// </summary>
    public class ReceivedInvoiceRecountPostModel : ValidatableModel
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
        public List<ReceivedInvoiceItemRecountPostModel> Items { get; set; }

        /// <summary>
        /// Gets or sets date of taxing.
        /// </summary>
        [RequiredIf(nameof(DateOfReceiving), null)]
        [DateGreaterOrEqualThan(Constants.DefaultDateTimeString, true)]
        public DateTime? DateOfTaxing { get; set; }

        /// <summary xml:lang="en">
        /// Gets or sets date of receiving.
        /// </summary>
        [RequiredIf(nameof(DateOfTaxing), null)]
        [DateGreaterOrEqualThan(Constants.DefaultDateTimeString, true)]
        public DateTime? DateOfReceiving { get; set; }
    }
}
