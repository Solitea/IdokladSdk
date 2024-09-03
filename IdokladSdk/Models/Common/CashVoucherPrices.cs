using System.Collections.Generic;

namespace IdokladSdk.Models.Common
{
    /// <summary>
    /// Cash voucher prices.
    /// </summary>
    public class CashVoucherPrices
    {
        /// <summary>
        /// Gets or sets vat rate summary.
        /// </summary>
        public List<VatRateSummaryItem> VatRateSummary { get; set; }
    }
}
