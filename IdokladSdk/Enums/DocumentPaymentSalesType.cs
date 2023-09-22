namespace IdokladSdk.Enums
{
    /// <summary>
    /// DocumentPaymentSalesType.
    /// </summary>
    public enum DocumentPaymentSalesType
    {
        /// <summary>
        /// All sales
        /// </summary>
        All = 0,

        /// <summary>
        /// Only issued invoice
        /// </summary>
        IssuedInvoice = 1,

        /// <summary>
        /// Only proforma invoice
        /// </summary>
        ProformaInvoice = 2,

        /// <summary>
        /// Only credit note
        /// </summary>
        CreditNote = 3,

        /// <summary>
        /// Only sales receipt
        /// </summary>
        SalesReceipt = 4
    }
}
