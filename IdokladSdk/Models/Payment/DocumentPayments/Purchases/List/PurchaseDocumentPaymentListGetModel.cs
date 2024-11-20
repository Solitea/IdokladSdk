using System;
using IdokladSdk.Models.Common;
using IdokladSdk.Models.Payment.DocumentPayments.Purchases.SubModels;
using IdokladSdk.Models.Payment.DocumentPayments.Sales.SubModels;

namespace IdokladSdk.Models.Payment.DocumentPayments.Purchases.List
{
    /// <summary>
    /// PurchaseDocumentPaymentListGetModel.
    /// </summary>
    public class PurchaseDocumentPaymentListGetModel
    {
        /// <summary>
        /// Gets or sets the currency ID.
        /// </summary>
        public int CurrencyId { get; set; }

        /// <summary>
        /// Gets or sets the currency symbol.
        /// </summary>
        public string CurrencySymbol { get; set; }

        /// <summary>
        /// Gets or sets the date of payment.
        /// </summary>
        public DateTime DateOfPayment { get; set; }

        /// <summary>
        /// Gets or sets the entity ID.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the paid document.
        /// </summary>
        public PaidPurchaseDocument PaidDocument { get; set; }

        /// <summary>
        /// Gets or sets the payment document (available for types IssuedInvoice, CreditNote, ProformaInvoice).
        /// </summary>
        public PaymentDocument PaymentDocument { get; set; }

        /// <summary>
        /// Gets or sets the payment option ID.
        /// </summary>
        public int PaymentOptionId { get; set; }

        /// <summary>
        /// Gets or sets the prices and calculations.
        /// </summary>
        public PaymentPrices Prices { get; set; }
    }
}
