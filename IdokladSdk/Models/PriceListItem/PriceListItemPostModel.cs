using System;
using System.ComponentModel.DataAnnotations;
using IdokladSdk.Enums;
using IdokladSdk.Validation.Attributes;

namespace IdokladSdk.Models.PriceListItem
{
    /// <summary>
    /// PriceListItemPostModel.
    /// </summary>
    public class PriceListItemPostModel
    {
        /// <summary>
        /// Gets or sets item amount.
        /// </summary>
        [Required]
        public decimal Amount { get; set; }

        /// <summary>
        /// Gets or sets item bar code.
        /// </summary>
        [StringLength(20)]
        public string BarCode { get; set; }

        /// <summary>
        /// Gets or sets item code.
        /// </summary>
        [StringLength(20)]
        public string Code { get; set; }

        /// <summary>
        /// Gets or sets currency id.
        /// </summary>
        [RequiredNonDefault]
        public int CurrencyId { get; set; }

        /// <summary>
        /// Gets or sets date of the initial stock movement.
        /// </summary>
        [DateGreaterOrEqualThan(Constants.DefaultDateTimeString, allowNull: true)]
        public DateTime? InitialDateStockBalance { get; set; }

        /// <summary>
        /// Gets or sets initial stock balance.
        /// </summary>
        public decimal? InitialStockBalance { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether stock item indicator.
        /// </summary>
        [Required]
        public bool IsStockItem { get; set; }

        /// <summary>
        /// Gets or sets item name.
        /// </summary>
        [StringLength(200)]
        [Required]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets unit price.
        /// </summary>
        [Required]
        public decimal Price { get; set; }

        /// <summary>
        /// Gets or sets price type.
        /// </summary>
        [Required]
        public PriceType PriceType { get; set; }

        /// <summary>
        /// Gets or sets unit of measure.
        /// </summary>
        [StringLength(20)]
        public string Unit { get; set; }

        /// <summary>
        /// Gets or sets VAT classification code.
        /// </summary>
        public int? VatCodeId { get; set; }

        /// <summary>
        /// Gets or sets VAT rate type.
        /// </summary>
        [Required]
        public VatRateType VatRateType { get; set; }
    }
}
