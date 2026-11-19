namespace IdokladSdk.Enums
{
    /// <summary>
    /// Received document types supported by the received invoices API.
    /// </summary>
    public enum ReceivedDocumentType : byte
    {
        /// <summary>Received invoice.</summary>
        ReceivedInvoice = DocumentType.ReceivedInvoice,

        /// <summary>Received credit note.</summary>
        ReceivedCreditNote = DocumentType.ReceivedCreditNote,

        /// <summary>Received debit note.</summary>
        ReceivedDebitNote = DocumentType.ReceivedDebitNote,

        /// <summary>Received tax document.</summary>
        ReceivedTaxDocument = DocumentType.ReceivedTaxDocument,

        /// <summary>Received proforma invoice.</summary>
        ReceivedProformaInvoice = DocumentType.ReceivedProformaInvoice
    }
}
