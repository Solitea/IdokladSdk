namespace IdokladSdk.Enums
{
    /// <summary>
    /// Mining source type.
    /// </summary>
    public enum MiningSourceType
    {
        /// <summary>
        /// ISDOC.
        /// </summary>
        Isdoc = 0,

        /// <summary>
        /// ZUGFeRD or Factur-X.
        /// </summary>
        ZugferdOrFacturX = 1,

        /// <summary>
        /// Rossum.
        /// </summary>
        Rossum = 2,

        /// <summary>
        /// QR invoice.
        /// </summary>
        QrInvoice = 3,

        /// <summary>
        /// Slovak QR invoice.
        /// </summary>
        QrInvoiceSk = 4,

        /// <summary>
        /// Invoice encoded in the Slovak Square format.
        /// </summary>
        InvoiceBySquare = 5,

        /// <summary>
        /// Payment encoded in the Slovak Square format.
        /// </summary>
        PayBySquare = 6,

        /// <summary>
        /// Invoice items encoded in the Slovak Square format.
        /// </summary>
        InvoiceItemsBySquare = 7,

        /// <summary>
        /// QR code payment.
        /// </summary>
        QrCodePayment = 8,

        /// <summary>
        /// GPT-based processing.
        /// </summary>
        Gpt = 9,

        /// <summary>
        /// Peppol electronic invoice.
        /// </summary>
        Peppol = 10,
    }
}
