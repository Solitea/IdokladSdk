namespace IdokladSdk.Models.BankStatement
{
    /// <summary>
    /// BankStatementItemPrices.
    /// </summary>
    public class BankStatementItemPrices
    {
        /// <summary>
        /// Gets or sets payment ammount.
        /// </summary>
        public decimal PaidAmount { get; set; }

        /// <summary>
        /// Gets or sets payment ammount in home currency.
        /// </summary>
        public decimal PaidAmountHc { get; set; }

        /// <summary>
        /// Gets or sets total price with vat.
        /// </summary>
        public decimal PriceTotalWithVat { get; set; }
    }
}
