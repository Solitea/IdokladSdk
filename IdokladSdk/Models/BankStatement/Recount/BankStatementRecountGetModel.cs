using System.Collections.Generic;
using IdokladSdk.Models.Common;

namespace IdokladSdk.Models.BankStatement.Recount
{
    /// <summary>
    /// BankStatementRecountGetModel.
    /// </summary>
    public class BankStatementRecountGetModel
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
        /// Gets or sets bank statement items.
        /// </summary>
        public List<BankStatementItemRecountGetModel> Items { get; set; }

        /// <summary>
        /// Gets or sets bank statement prices.
        /// </summary>
        public Prices Prices { get; set; }
    }
}
