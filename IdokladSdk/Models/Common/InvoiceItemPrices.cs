namespace IdokladSdk.Models.Common
{
    /// <summary>
    /// InvoiceItemPrices.
    /// </summary>
    public class InvoiceItemPrices : ItemPrices
    {
        /// <summary>
        /// Gets or sets total with vat before discount.
        /// </summary>
        public decimal TotalWithVatBeforeDiscount { get; set; }

        /// <summary>
        /// Gets or sets total without vat before discount.
        /// </summary>
        public decimal TotalWithoutVatBeforeDiscount { get; set; }

        /// <summary>
        /// Gets or sets total vat before discount.
        /// </summary>
        public decimal TotalVatBeforeDiscount { get; set; }
    }
}
