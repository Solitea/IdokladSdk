using System;
using IdokladSdk.Enums;
using IdokladSdk.Models.Common;

namespace IdokladSdk.Models.Payment.DocumentPayments.Sales.Detail
{
    /// <summary>
    /// SalesPaymentBaseGetModel.
    /// </summary>
    public class SalesPaymentBaseGetModel : IEntityId
    {
        /// <summary>
        /// Gets or sets currency.
        /// </summary>
        public int CurrencyId { get; set; }

        /// <summary>
        /// Gets or sets currency symbol.
        /// </summary>
        public string CurrencySymbol { get; set; }

        /// <summary>
        /// Gets or sets date of maturity.
        /// </summary>
        public DateTime DateOfMaturity { get; set; }

        /// <summary>
        /// Gets or sets date of payment.
        /// </summary>
        public DateTime DateOfPayment { get; set; }

        /// <summary>
        /// Gets or sets date of description.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets date of document number.
        /// </summary>
        public string DocumentNumber { get; set; }

        /// <summary>
        /// Gets or sets exported.
        /// </summary>
        public ExportedState Exported { get; set; }

        /// <inheritdoc/>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets is income tax.
        /// </summary>
        public bool IsIncomeTax { get; set; }

        /// <summary>
        /// Gets or sets partner id.
        /// </summary>
        public int? PartnerId { get; set; }

        /// <summary>
        /// Gets or sets partner name.
        /// </summary>
        public string PartnerName { get; set; }

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
