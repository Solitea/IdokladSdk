namespace IdokladSdk.Enums
{
    /// <summary>
    /// Paired Document Type.
    /// </summary>
    public enum PairedDocumentType : byte
    {
        /// <summary>
        /// Issued invoice
        /// </summary>
        IssuedInvoice = DocumentType.IssuedInvoice,

        /// <summary>
        /// Proforma invoice
        /// </summary>
        ProformaInvoice = DocumentType.ProformaInvoice,

        /// <summary>
        /// Credit note
        /// </summary>
        CreditNote = DocumentType.CreditNote,

        /// <summary>
        /// Received invoice
        /// </summary>
        ReceivedInvoice = DocumentType.ReceivedInvoice,

        /// <summary>
        /// Received Receipt
        /// </summary>
        ReceivedReceipt = DocumentType.ReceivedReceipt,

        /// <summary>
        /// Debit note
        /// </summary>
        IssuedDebitNote = DocumentType.IssuedDebitNote,

        /// <summary>Received credit note.</summary>
        ReceivedCreditNote = DocumentType.ReceivedCreditNote,

        /// <summary>Received debit note.</summary>
        ReceivedDebitNote = DocumentType.ReceivedDebitNote,

        /// <summary>Received proforma invoice.</summary>
        ReceivedProformaInvoice = DocumentType.ReceivedProformaInvoice,
    }
}
