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
        ReceivedReceiptAttachment = 110,

        /// <summary>Received credit note.</summary>
        ReceivedCreditNote = 13,

        /// <summary>Attachment of a received credit note.</summary>
        ReceivedCreditNoteAttachment = 130,

        /// <summary>Received debit note.</summary>
        ReceivedDebitNote = 14,

        /// <summary>Attachment of a received debit note.</summary>
        ReceivedDebitNoteAttachment = 140,

        /// <summary>Received tax document.</summary>
        ReceivedTaxDocument = 15,

        /// <summary>Attachment of a received tax document.</summary>
        ReceivedTaxDocumentAttachment = 150,

        /// <summary>Received proforma invoice.</summary>
        ReceivedProformaInvoice = 16,

        /// <summary>Attachment of a received proforma invoice.</summary>
        ReceivedProformaInvoiceAttachment = 160
    }
}
