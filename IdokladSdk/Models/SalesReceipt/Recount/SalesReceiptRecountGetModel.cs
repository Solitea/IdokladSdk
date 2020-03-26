using System.Collections.Generic;
using IdokladSdk.Models.Common;

namespace IdokladSdk.Models.SalesReceipt
{
    /// <summary>
    /// SalesReceipt model for Recount Get endpoint.
    /// </summary>
    public class SalesReceiptRecountGetModel
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
        /// Gets or sets List of items.
        /// </summary>
        public List<SalesReceiptItemRecountGetModel> Items { get; set; }

        /// <summary>
        /// Gets or sets Payments.
        /// </summary>
        public List<SalesReceiptPaymentRecountGetModel> Payments { get; set; }

        /// <summary>
        /// Gets or sets recounted prices.
        /// </summary>
        public Prices Prices { get; set; }
    }
}
