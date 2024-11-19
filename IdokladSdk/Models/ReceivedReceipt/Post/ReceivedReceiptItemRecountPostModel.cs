﻿using System.ComponentModel.DataAnnotations;
using IdokladSdk.Enums;

namespace IdokladSdk.Models.ReceivedReceipt.Post
{
    /// <summary>
    /// ReceivedReceiptItemRecountPostModel.
    /// </summary>
    public class ReceivedReceiptItemRecountPostModel
    {
        /// <summary>
        /// Gets or sets the item amount.
        /// </summary>
        [Required]
        public decimal Amount { get; set; }

        /// <summary>
        /// Gets or sets the custom VAT value.
        /// </summary>
        public decimal? CustomVat { get; set; }

        /// <summary>
        /// Gets or sets the entity's ID.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the item name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the price type.
        /// </summary>
        [Required]
        public PriceTypeWithoutOnlyBase PriceType { get; set; }

        /// <summary>
        /// Gets or sets the unit price.
        /// </summary>
        [Required]
        public decimal UnitPrice { get; set; }

        /// <summary>
        /// Gets or sets the VAT rate type.
        /// </summary>
        [Required]
        public VatRateType VatRateType { get; set; }
    }
}
