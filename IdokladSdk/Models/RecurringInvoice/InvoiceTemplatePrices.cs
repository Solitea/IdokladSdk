using System.Collections.Generic;
using IdokladSdk.Models.Common;

namespace IdokladSdk.Models.RecurringInvoice
{
    /// <summary>
    /// InvoiceTemplatePrices.
    /// </summary>
    public class InvoiceTemplatePrices : Prices
    {
        /// <summary>
        /// Gets or sets total amount of discount. If the invoice is without discount, this will be zero.
        /// </summary>
        public decimal TotalDiscountAmount { get; set; }

        /// <summary>
        /// Gets or sets total amount without discount. If the invoice is without discount, this will be zero.
        /// </summary>
        public decimal TotalWithoutDiscount { get; set; }

        /// <summary>
        /// Gets or sets VAT rate summary.
        /// </summary>
        public List<VatRateSummaryItem> VatRateSummary { get; set; }
    }
}
