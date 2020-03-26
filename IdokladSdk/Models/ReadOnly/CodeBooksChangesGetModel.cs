namespace IdokladSdk.Models.ReadOnly
{
    /// <summary>
    /// Indication of changes of codebooks.
    /// </summary>
    public class CodeBooksChangesGetModel
    {
        /// <summary>
        /// Gets or sets a value indicating whether bank code book has changed.
        /// </summary>
        public bool Bank { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether constant symbols code book has changed.
        /// </summary>
        public bool ConstantSymbols { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether constant symbols code book has changed.
        /// </summary>
        public bool Country { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether currencies code book has changed.
        /// </summary>
        public bool Currencies { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether exchange rates code book has changed.
        /// </summary>
        public bool ExchangeRates { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether payment options code book has changed.
        /// </summary>
        public bool PaymentOptions { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether VAT codes code book has changed.
        /// </summary>
        public bool VatCodes { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether VAT rates code book has changed.
        /// </summary>
        public bool VatRates { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether VAT reverse charge codes code book has changed.
        /// Only for Cz legislation.
        /// </summary>
        public bool VatReverseChargeCodes { get; set; }
    }
}
