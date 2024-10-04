using System;
using IdokladSdk.Models.Common;

namespace IdokladSdk.Models.BankStatement
{
    /// <summary>
    /// BankStatementItemPrices.
    /// </summary>
    public class BankStatementItemPrices : ItemPrices
    {
        /// <summary>
        /// Gets or sets payment ammount.
        /// </summary>
        [Obsolete("Use TotalWithVat instead.")]
        public decimal PaidAmount { get; set; }

        /// <summary>
        /// Gets or sets payment ammount in home currency.
        /// </summary>
        [Obsolete("Use TotalWithVatHc instead.")]
        public decimal PaidAmountHc { get; set; }

        /// <summary>
        /// Gets or sets total price with vat.
        /// </summary>
        [Obsolete("Use TotalWithVatHc instead")]
        public decimal PriceTotalWithVat { get; set; }
    }
}
