using System.Collections.Generic;
using IdokladSdk.Models.Common;

namespace IdokladSdk.Models.CashVoucher.Recount
{
    public class CashVoucherRecountGetModel
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
        /// Gets or sets cash voucher items.
        /// </summary>
        public List<CashVoucherItemRecountGetModel> Items { get; set; }

        /// <summary>
        /// Gets or sets cash voucher prices.
        /// </summary>
        public CashVoucherPrices Prices { get; set; }
    }
}
