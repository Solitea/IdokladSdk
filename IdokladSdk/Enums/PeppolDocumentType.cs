namespace IdokladSdk.Enums
{
    /// <summary>
    /// Document types supported by electronic document downloads.
    /// </summary>
    public enum PeppolDocumentType
    {
        /// <summary>Issued invoice.</summary>
        IssuedInvoice = DocumentType.IssuedInvoice,

        /// <summary>Credit note.</summary>
        CreditNote = DocumentType.CreditNote,

        /// <summary>Issued debit note.</summary>
        IssuedDebitNote = DocumentType.IssuedDebitNote,

        /// <summary>Issued tax document.</summary>
        IssuedTaxDocument = DocumentType.IssuedTaxDocument
    }
}
