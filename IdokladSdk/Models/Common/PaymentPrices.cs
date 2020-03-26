namespace IdokladSdk.Models.Common
{
    /// <summary>
    /// PaymentPrices.
    /// </summary>
    public class PaymentPrices
    {
        /// <summary>
        /// Gets or sets Payment ammount.
        /// </summary>
        public decimal PaymentAmount { get; set; }

        /// <summary>
        /// Gets or sets Payment ammount in home currency.
        /// </summary>
        public decimal PaymentAmountHc { get; set; }
    }
}
