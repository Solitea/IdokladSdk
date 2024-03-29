﻿using System.ComponentModel.DataAnnotations;
using IdokladSdk.Enums;
using IdokladSdk.Models.Common;

namespace IdokladSdk.Models.ReceivedInvoice
{
    /// <summary>
    /// ReceivedInvoiceItemRecountPostModel.
    /// </summary>
    public class ReceivedInvoiceItemRecountPostModel : ItemRecountPostModel
    {
        /// <summary>
        /// Gets or sets indicates if item has custom Vat value.
        /// </summary>
        public decimal? CustomVatRate { get; set; }

        /// <summary>
        /// Gets or sets price type.
        /// </summary>
        [Required]
        public PriceType? PriceType { get; set; }
    }
}
