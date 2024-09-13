namespace IdokladSdk.Enums
{
    /// <summary>
    /// Set of types of exportable entitites.
    /// </summary>
    public enum ExportableEntityType
    {
        /// <summary>
        /// Cash voucher
        /// </summary>
        CashVoucher = 0,

        /// <summary>
        /// Contact
        /// </summary>
        Contact = 1,

        /// <summary>
        /// Credit node
        /// </summary>
        CreditNote = 2,

        /// <summary>
        /// Issued invoice
        /// </summary>
        IssuedInvoice = 3,

        /// <summary>
        /// Issued invoice payment
        /// </summary>
        IssuedInvoicePayment = 4,

        /// <summary>
        /// Received invoice payment
        /// </summary>
        ReceivedInvoicePayment = 5,

        /// <summary>
        /// Proforma invoice
        /// </summary>
        ProformaInvoice = 6,

        /// <summary>
        /// Received invoice
        /// </summary>
        ReceivedInvoice = 7,

        /// <summary>
        /// Sales receipt
        /// </summary>
        SalesReceipt = 8,
        
        /// <summary>
        /// Item of a price list
        /// </summary>
        PriceListItem = 10,

        /// <summary>
        /// Issued tax document
        /// </summary>
        IssuedTaxDocument = 11,
    }
}
