using System;
using IdokladSdk.Models.Common;

namespace IdokladSdk.Models.IssuedDocumentPayment
{
    /// <summary>
    /// s.
    /// </summary>
    public class PaymentsForIssuedTaxDocumentGetModel
    {
        /// <summary>
        /// Gets or sets CurrencyId.
        /// </summary>
        public int CurrencyId { get; set; }

        /// <summary>
        /// Gets or sets CurrencySymbol.
        /// </summary>
        public string CurrencySymbol { get; set; }

        /// <summary>
        /// Gets or sets DateOfPayment.
        /// </summary>
        public DateTime DateOfPayment { get; set; }

        /// <summary>
        /// Gets or sets Description.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets DocumentNumber.
        /// </summary>
        public string DocumentNumber { get; set; }

        /// <summary>
        /// Gets or sets Id.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets IdentificationNumber.
        /// </summary>
        public string IdentificationNumber { get; set; }

        /// <summary>
        /// Gets or sets InvoiceId.
        /// </summary>
        public int InvoiceId { get; set; }

        /// <summary>
        /// Gets or sets PartnerId.
        /// </summary>
        public int PartnerId { get; set; }

        /// <summary>
        /// Gets or sets PartnerName.
        /// </summary>
        public string PartnerName { get; set; }

        /// <summary>
        /// Gets or sets Prices.
        /// </summary>
        public PaymentPrices Prices { get; set; }

        /// <summary>
        /// Gets or sets VatIdentificationNumber.
        /// </summary>
        public string VatIdentificationNumber { get; set; }
    }
}
