namespace IdokladSdk.Enums
{
    /// <summary>
    /// Method used to send an electronic invoice by email.
    /// </summary>
    public enum EInvoiceSendMethod
    {
        /// <summary>Send the XML document as an attachment.</summary>
        Attachment = 0,

        /// <summary>Send the document as a link.</summary>
        Link = 1
    }
}
