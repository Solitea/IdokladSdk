namespace IdokladSdk.Models.Common
{
    /// <summary>
    /// ItemPrices.
    /// </summary>
    public class ItemPrices
    {
        /// <summary>
        /// Gets or sets Total price without VAT.
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

        /// <summary>
        /// Gets or sets unit price.
        /// </summary>
        public decimal UnitPrice { get; set; }

        /// <summary>
        /// Gets or sets total VAT.
        /// </summary>
        public decimal TotalVat { get; set; }

        /// <summary>
        /// Gets or sets total VAT in home currency.
        /// </summary>
        public decimal TotalVatHc { get; set; }
    }
}
