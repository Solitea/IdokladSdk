namespace IdokladSdk.Enums
{
    /// <summary>
    /// ReceivedDocumentPaymentDocumentType.
    /// </summary>
    public enum ReceivedDocumentPaymentDocumentType
    {
        /// <summary>
        /// Received invoice.
        /// </summary>
        ReceivedInvoice = DocumentType.ReceivedInvoice,

        /// <summary>
        /// Received credit note.
        /// </summary>
        ReceivedCreditNote = DocumentType.ReceivedCreditNote,

        /// <summary>
        /// Received debit note.
        /// </summary>
        ReceivedDebitNote = DocumentType.ReceivedDebitNote,

        /// <summary>
        /// Received proforma invoice.
        /// </summary>
        ReceivedProformaInvoice = DocumentType.ReceivedProformaInvoice,
    }
}
