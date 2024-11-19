using System.Collections.Generic;
using IdokladSdk.Models.Common;

namespace IdokladSdk.Models.ReceivedReceipt.Get
{
    /// <summary>
    /// ReceivedReceiptRecountGetModel.
    /// </summary>
    public class ReceivedReceiptRecountGetModel
    {
        /// <summary>
        /// Gets or sets the currency ID.
        /// </summary>
        public int CurrencyId { get; set; }

        /// <summary>
        /// Gets or sets the exchange rate.
        /// </summary>
        public decimal ExchangeRate { get; set; }

        /// <summary>
        /// Gets or sets the exchange rate amount.
        /// </summary>
        public decimal ExchangeRateAmount { get; set; }

        /// <summary>
        /// Gets or sets the list of invoice items.
        /// </summary>
        public List<ReceivedReceiptItemRecountGetModel> Items { get; set; }

        /// <summary>
        /// Gets or sets the summary of recounted prices.
        /// </summary>
        public Prices Prices { get; set; }
    }
}
