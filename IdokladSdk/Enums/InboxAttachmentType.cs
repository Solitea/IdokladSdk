namespace IdokladSdk.Enums
{
    /// <summary>
    /// Inbox attachment type.
    /// </summary>
    public enum InboxAttachmentType
    {
        /// <summary>
        /// None.
        /// </summary>
        None = 0,

        /// <summary>
        /// Received invoice.
        /// </summary>
        ReceivedInvoice = 5,

        /// <summary>
        /// Received receipt.
        /// </summary>
        ReceivedReceipt = 11,

        /// <summary>
        /// Received invoice attachment.
        /// </summary>
        ReceivedInvoiceAttachment = 50,

        /// <summary>
        /// Received receipt attachment.
        /// </summary>
        ReceivedReceiptAttachment = 110
    }
}
