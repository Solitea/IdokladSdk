using System;
using System.ComponentModel.DataAnnotations;
using IdokladSdk.Models.Base;
using IdokladSdk.Models.RegisteredSale;
using IdokladSdk.Validation.Attributes;

namespace IdokladSdk.Models.IssuedDocumentPayment
{
    /// <summary>
    /// IssuedDocumentPaymentPostModel.
    /// </summary>
    public class IssuedDocumentPaymentPostModel : ValidatableModel
    {
        /// <summary>
        /// Gets or sets date of payment.
        /// </summary>
        [Required]
        public DateTime DateOfPayment { get; set; }

        /// <summary>
        /// Gets or sets date of vat application.
        /// Only for Sk legislation.
        /// </summary>
        public DateTime? DateOfVatApplication { get; set; }

        /// <summary>
        /// Gets or sets electronic records of sales information.
        /// Only for Cz legislation.
        /// </summary>
        public ElectronicRecordsOfSalesPostModel ElectronicRecordsOfSales { get; set; }

        /// <summary>
        /// Gets or sets invoice id.
        /// </summary>
        [RequiredNonDefault]
        public int InvoiceId { get; set; }

        /// <summary>
        /// Gets or sets payment amount.
        /// </summary>
        [Required]
        public decimal PaymentAmount { get; set; }

        /// <summary>
        /// Gets or sets payment option id.
        /// </summary>
        [RequiredNonDefault]
        public int PaymentOptionId { get; set; }

        /// <summary>
        /// Gets or sets POS equipment Id.
        /// Only for Cz legislation.
        /// </summary>
        [NullableForeignKey]
        public int? SalesPosEquipmentId { get; set; }

        /// <summary>
        /// Gets or sets send payment confirmation.
        /// </summary>
        public bool? SendPaymentConfirmation { get; set; }
    }
}
