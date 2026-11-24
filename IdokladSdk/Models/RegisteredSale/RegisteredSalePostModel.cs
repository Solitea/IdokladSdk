using System;
using System.ComponentModel.DataAnnotations;
using IdokladSdk.Models.Base;
using IdokladSdk.Validation.Attributes;

namespace IdokladSdk.Models.RegisteredSale
{
    /// <summary>
    /// RegisteredSale Model for Post endpoints.
    /// </summary>
    public class RegisteredSalePostModel : ValidatableModel
    {
        /// <summary>
        /// Gets or sets Canceled registered sale id.
        /// </summary>
        [NullableForeignKey]
        public int? CancelledRegisteredSaleId { get; set; }

        /// <summary>
        /// Gets or sets Date of answer.
        /// </summary>
        [Required]
        public DateTime DateOfAnswer { get; set; }

        /// <summary>
        /// Gets or sets Date of sale.
        /// </summary>
        [Required]
        public DateTime DateOfSale { get; set; }

        /// <summary>
        /// Gets or sets Date of send.
        /// </summary>
        [Required]
        public DateTime DateOfSend { get; set; }

        /// <summary>
        /// Gets or sets the confirmation code.
        /// </summary>
        [Required]
        public string Pok { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether sale is canceled.
        /// </summary>
        public bool IsCanceled { get; set; }

        /// <summary>
        /// Gets or sets the total price including VAT in home currency.
        /// </summary>
        [Required]
        public decimal TotalWithVat { get; set; }

        /// <summary>
        /// Gets or sets the amount in CZK received for later use or settlement.
        /// </summary>
        public decimal TotalAdvancePayment { get; set; }

        /// <summary>
        /// Gets or sets the amount in CZK used or settled from a previously received payment.
        /// </summary>
        public decimal TotalFromAdvancePayment { get; set; }

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
    }
}
