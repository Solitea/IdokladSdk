using System.Collections.Generic;

namespace IdokladSdk.Models.IssuedInvoice
{
    /// <summary>
    /// IssuedInvoiceRecountGetModel.
        /// </summary>
    public class IssuedInvoiceRecountGetModel
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
        /// Gets or sets invoice items.
        /// </summary>
        public List<IssuedInvoiceItemRecountGetModel> Items { get; set; }

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
