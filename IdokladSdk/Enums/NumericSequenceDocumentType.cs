namespace IdokladSdk.Enums
{
    /// <summary>
    /// NumericSequenceDocumentType.
    /// </summary>
    public enum NumericSequenceDocumentType
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
        /// Cash voucher
        /// </summary>
        CashVoucher = DocumentType.CashVoucher,

        /// <summary>
        /// Credit note - you need define own numeric sequence for credit note
        /// </summary>
        CreditNote = DocumentType.CreditNote,

        /// <summary>
        /// Bank statement
        /// </summary>
        BankStatement = DocumentType.BankStatement,

        /// <summary>
        /// Received invoice
        /// </summary>
        ReceivedInvoice = DocumentType.ReceivedInvoice,

        /// <summary>
        /// Sales receipt
        /// </summary>
        SalesReceipt = DocumentType.SalesReceipt,

        /// <summary>
        /// Sales Order
        /// </summary>
        SalesOrder = DocumentType.SalesOrder,

        /// <summary>
        /// Internal document
        /// </summary>
        InternalDocument = DocumentType.InternalDocument,

        /// <summary>
        /// Issued tax document
        /// </summary>
        IssuedTaxDocument = DocumentType.IssuedTaxDocument,

        /// <summary>
        /// Received Receipt
        /// </summary>
        ReceivedReceipt = DocumentType.ReceivedReceipt,
    }
}
