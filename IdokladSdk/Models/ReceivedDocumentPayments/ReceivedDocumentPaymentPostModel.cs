using System;
using System.ComponentModel.DataAnnotations;
using IdokladSdk.Validation.Attributes;

namespace IdokladSdk.Models.ReceivedDocumentPayments
{
    /// <summary>
    /// ReceivedDocumentPayment model for POST endpoint.
    /// </summary>
    public class ReceivedDocumentPaymentPostModel
    {
        /// <summary>
        /// Gets or sets date of payment.
        /// </summary>
        [Required]
        public DateTime DateOfPayment { get; set; }

        /// <summary>
        /// Gets or sets date of vat application.
        /// </summary>
        public DateTime? DateOfVatApplication { get; set; }

        /// <summary>
        /// Gets or sets document Id.
        /// </summary>
        [RequiredNonDefault]
        public int InvoiceId { get; set; }

        /// <summary>
        /// Gets or sets payment ammount.
        /// </summary>
        [Required]
        public decimal PaymentAmount { get; set; }

        /// <summary>
        /// Gets or sets payment option id.
        /// </summary>
        [RequiredNonDefault]
        public int PaymentOptionId { get; set; }
    }
}
