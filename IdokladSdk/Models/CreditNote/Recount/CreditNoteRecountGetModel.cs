using System.Collections.Generic;
using IdokladSdk.Enums;
using IdokladSdk.Models.IssuedInvoice;

namespace IdokladSdk.Models.CreditNote
{
    /// <summary>
    /// CreditNoteRecountGetModel.
    /// </summary>
    public class CreditNoteRecountGetModel
    {
        /// <summary>
        /// Gets or sets currency id.
        /// </summary>
        public int CurrencyId { get; set; }

        /// <summary>
        /// Gets or sets exchange rate.
        /// </summary>
        public decimal ExchangeRate { get; set; }

        /// <summary>
        /// Gets or sets exchange rate amount.
        /// </summary>
        public decimal ExchangeRateAmount { get; set; }

        /// <summary>
        /// Gets or sets discount.
        /// </summary>
        public decimal DiscountPercentage { get; set; }

        /// <summary>
        /// Gets or sets discount type.
        /// </summary>
        public DiscountType DiscountType { get; set; }

        /// <summary>
        /// Gets or sets invoice items.
        /// </summary>
        public List<CreditNoteItemRecountGetModel> Items { get; set; }

        /// <summary>
        /// Gets or sets payment option id.
        /// </summary>
        public int PaymentOptionId { get; set; }

        /// <summary>
        /// Gets or sets prices and calculations.
        /// </summary>
        public IssuedInvoicePrices Prices { get; set; }
    }
}
