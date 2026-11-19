namespace IdokladSdk.Enums
{
    /// <summary>
    /// PurchasePaymentForDocumentType.
    /// </summary>
    public enum PurchasePaymentForDocumentType
    {
        /// <summary>
        /// Received invoice
        /// </summary>
        ReceivedInvoice = DocumentType.ReceivedInvoice,

        /// <summary>
        /// Received Receipt
        /// </summary>
        ReceivedReceipt = DocumentType.ReceivedReceipt,

        /// <summary>
        /// Received credit note
        /// </summary>
        ReceivedCreditNote = DocumentType.ReceivedCreditNote,

        /// <summary>
        /// Received debit note
        /// </summary>
        ReceivedDebitNote = DocumentType.ReceivedDebitNote,

        /// <summary>
        /// Received proforma invoice
        /// </summary>
        ReceivedProformaInvoice = DocumentType.ReceivedProformaInvoice,
    }
}
