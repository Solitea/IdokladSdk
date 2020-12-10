using System.Collections.Generic;

namespace IdokladSdk.Models.RecurringInvoice
{
    /// <summary>
    /// InvoiceTemplateRecountGetModel.
    /// </summary>
    public class InvoiceTemplateRecountGetModel
    {
        /// <summary>
        /// Gets or sets currency Id.
        /// </summary>
        public int CurrencyId { get; set; }

        /// <summary>
        /// Gets or sets discount.
        /// </summary>
        public decimal DiscountPercentage { get; set; }

        /// <summary>
        /// Gets or sets invoice items.
        /// </summary>
        public List<InvoiceItemTemplateRecountGetModel> Items { get; set; }

        /// <summary>
        /// Gets or sets prices and calculations.
        /// </summary>
        public InvoiceTemplatePrices Prices { get; set; }

        /// <summary>
        /// Gets or sets payment option Id.
        /// </summary>
        public int PaymentOptionId { get; set; }
    }
}
