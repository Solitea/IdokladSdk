namespace IdokladSdk.Enums
{
    /// <summary>
    /// IssuedDocumentTemplateType.
    /// </summary>
    public enum IssuedDocumentTemplateType : byte
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
        /// Sales order
        /// </summary>
        SalesOrder = DocumentType.SalesOrder
    }
}
