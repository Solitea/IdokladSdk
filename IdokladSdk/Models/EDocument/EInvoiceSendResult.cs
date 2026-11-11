namespace IdokladSdk.Models.EDocument
{
    /// <summary>
    /// Electronic invoice delivery result.
    /// </summary>
    public class EInvoiceSendResult
    {
        /// <summary>Gets or sets a value indicating whether sending succeeded.</summary>
        public bool IsSuccess { get; set; }

        /// <summary>Gets or sets the delivery result message.</summary>
        public string Message { get; set; }
    }
}
