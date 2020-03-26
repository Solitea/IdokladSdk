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
        IssuedInvoice = 0,

        /// <summary>
        /// Proforma invoice
        /// </summary>
        ProformaInvoice = 1,

        /// <summary>
        /// Cash voucher
        /// </summary>
        CashVoucher = 2,

        /// <summary>
        /// Credit note - you need define own numeric sequence for credit note
        /// </summary>
        CreditNote = 3,

        /// <summary>
        /// Bank statement
        /// </summary>
        BankStatement = 4,

        /// <summary>
        /// Received invoice
        /// </summary>
        ReceivedInvoice = 5,

        /// <summary>
        /// Sales receipt
        /// </summary>
        SalesReceipt = 6,

        /// <summary>
        /// Sales Order
        /// </summary>
        SalesOrder = 7,

        /// <summary>
        /// Internal document
        /// </summary>
        InternalDocument = 9,
    }
}
