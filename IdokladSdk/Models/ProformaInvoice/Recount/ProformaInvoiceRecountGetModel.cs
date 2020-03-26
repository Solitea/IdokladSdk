using System.Collections.Generic;
using IdokladSdk.Models.Common;

namespace IdokladSdk.Models.ProformaInvoice
{
    /// <summary>
    /// ProformaInvoiceRecountGetModel.
    /// </summary>
    public class ProformaInvoiceRecountGetModel
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
        /// Gets or sets invoice items.
        /// </summary>
        public List<ProformaInvoiceItemRecountGetModel> Items { get; set; }

        /// <summary>
        /// Gets or sets payment option id.
        /// </summary>
        public int PaymentOptionId { get; set; }

        /// <summary>
        /// Gets or sets prices and calculations.
        /// </summary>
        public InvoicePrices Prices { get; set; }
    }
}
