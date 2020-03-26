using System;
using System.ComponentModel.DataAnnotations;
using IdokladSdk.Validation.Attributes;

namespace IdokladSdk.Models.RegisteredSale
{
    /// <summary>
    /// RegisteredSale Model for Post enpoints.
    /// </summary>
    public class RegisteredSalePostModel
    {
        /// <summary>
        /// Gets or sets Taxpayers security code.
        /// </summary>
        [Required]
        public string Bkp { get; set; }

        /// <summary>
        /// Gets or sets Canceled registered sale id.
        /// </summary>
        [NullableForeignKey]
        public int? CancelledRegisteredSaleId { get; set; }

        /// <summary>
        /// Gets or sets Date of answer.
        /// </summary>
        public DateTime DateOfAnswer { get; set; }

        /// <summary>
        /// Gets or sets Date of sale.
        /// </summary>
        public DateTime DateOfSale { get; set; }

        /// <summary>
        /// Gets or sets Date of send.
        /// </summary>
        public DateTime DateOfSend { get; set; }

        /// <summary>
        /// Gets or sets Fiscal identification code.
        /// </summary>
        [Required]
        public string Fik { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether sale is canceled.
        /// </summary>
        public bool IsCanceled { get; set; }

        /// <summary>
        /// Gets or sets Taxpayers signature code.
        /// </summary>
        [Required]
        public string Pkp { get; set; }

        /// <summary>
        /// Gets or sets Registered sale prices.
        /// </summary>
        public RegisteredSalePrices Prices { get; set; }

        /// <summary>
        /// Gets or sets Receipt number.
        /// </summary>
        [Required]
        public string ReceiptNumber { get; set; }

        /// <summary>
        /// Gets or sets Sales office designation.
        /// </summary>
        [Required]
        public int SalesOfficeDesignation { get; set; }

        /// <summary>
        /// Gets or sets Point of sale equipment id.
        /// </summary>
        [NullableForeignKey]
        public int? SalesPosEquipmentId { get; set; }

        /// <summary>
        /// Gets or sets Universally unique identifier.
        /// </summary>
        [Required]
        public Guid Uuid { get; set; }

        /// <summary>
        /// Gets or sets VAT of taxpayer.
        /// </summary>
        [Required]
        public string VatIdentificationNumber { get; set; }
    }
}
