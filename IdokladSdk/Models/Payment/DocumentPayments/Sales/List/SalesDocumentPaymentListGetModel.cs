using System;
using IdokladSdk.Models.Common;
using IdokladSdk.Models.Payment.DocumentPayments.Sales.SubModels;

namespace IdokladSdk.Models.Payment.DocumentPayments.Sales.List
{
    /// <summary>
    /// SalesDocumentPaymentListGetModel.
    /// </summary>
    public class SalesDocumentPaymentListGetModel : IEntityId
    {
        /// <summary>
        /// Gets or sets id of accounting invoice (available for type ProformaInvoice).
        /// </summary>
        public int? AccountedByInvoiceId { get; set; }

        /// <summary>
        /// Gets or sets currency id.
        /// </summary>
        public int CurrencyId { get; set; }

        /// <summary>
        /// Gets or sets currency symbol.
        /// </summary>
        public string CurrencySymbol { get; set; }

        /// <summary>
        /// Gets or sets date of payment.
        /// </summary>
        public DateTime DateOfPayment { get; set; }

        /// <inheritdoc/>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether payment is accounted (available for type ProformaInvoice).
        /// </summary>
        public bool IsAccounted { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether confirmation is sent.
        /// </summary>
        public bool IsConfirmationSent { get; set; }

        /// <summary>
        /// Gets or sets issued tax document id.
        /// </summary>
        public int? IssuedTaxDocumentId { get; set; }

        /// <summary>
        /// Gets or sets paid document.
        /// </summary>
        public PaidDocument PaidDocument { get; set; }

        /// <summary>
        /// Gets or sets payment document.
        /// </summary>
        public PaymentDocument PaymentDocument { get; set; }

        /// <summary>
        /// Gets or sets payment option id.
        /// </summary>
        public int PaymentOptionId { get; set; }

        /// <summary>
        /// Gets or sets prices.
        /// </summary>
        public PaymentPrices Prices { get; set; }
    }
}
