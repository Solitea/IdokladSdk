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
    }
}
