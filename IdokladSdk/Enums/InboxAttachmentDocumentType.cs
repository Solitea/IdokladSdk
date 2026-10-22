namespace IdokladSdk.Enums
{
    /// <summary>
    /// Inbox attachment document type.
    /// </summary>
    public enum InboxAttachmentDocumentType
    {
        /// <summary>
        /// Received invoice.
        /// </summary>
        ReceivedInvoice = 5,

        /// <summary>
        /// Received receipt.
        /// </summary>
        ReceivedReceipt = 11,

        /// <summary>Received credit note.</summary>
        ReceivedCreditNote = 13,

        /// <summary>Received debit note.</summary>
        ReceivedDebitNote = 14,

        /// <summary>Received tax document.</summary>
        ReceivedTaxDocument = 15,

        /// <summary>Received proforma invoice.</summary>
        ReceivedProformaInvoice = 16
    }
}
