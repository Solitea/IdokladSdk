namespace IdokladSdk.Enums
{
    /// <summary>
    /// Channel used to deliver an electronic invoice.
    /// </summary>
    public enum EInvoiceChannel : byte
    {
        /// <summary>No delivery channel.</summary>
        None = 0,

        /// <summary>XML was downloaded.</summary>
        XmlDownloaded = 1,

        /// <summary>XML was sent by email.</summary>
        XmlSentViaMail = 2,

        /// <summary>XML was sent through Peppol.</summary>
        XmlSentViaPeppol = 3
    }
}
