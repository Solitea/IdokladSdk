namespace IdokladSdk.Models.Common
{
    /// <summary>
    /// Prices.
    /// </summary>
    public class Prices
    {
        /// <summary>
        /// Gets or sets total VAT.
        /// </summary>
        public decimal TotalVat { get; set; }

        /// <summary>
        /// Gets or sets total VAT in home currency.
        /// </summary>
        public decimal TotalVatHc { get; set; }

        /// <summary>
        /// Gets or sets total price without VAT.
        /// </summary>
        public decimal TotalWithoutVat { get; set; }

        /// <summary>
        /// Gets or sets total price without VAT in home currency.
        /// </summary>
        public decimal TotalWithoutVatHc { get; set; }

        /// <summary>
        /// Gets or sets total price with VAT.
        /// </summary>
        public decimal TotalWithVat { get; set; }

        /// <summary>
        /// Gets or sets total price with VAT in home currency.
        /// </summary>
        public decimal TotalWithVatHc { get; set; }
    }
}
