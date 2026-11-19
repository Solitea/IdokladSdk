namespace IdokladSdk.Enums
{
    /// <summary>
    /// DocumentPaymentPurchaseType.
    /// </summary>
    public enum DocumentPaymentPurchaseType
    {
        /// <summary>
        /// All sales
        /// </summary>
        All = 0,

        /// <summary>
        /// Only received invoice
        /// </summary>
        ReceivedInvoice = 1,

        /// <summary>
        /// Only received receipt
        /// </summary>
        ReceivedReceipt = 2,

        /// <summary>
        /// Received credit and debit note
        /// </summary>
        ReceivedCreditNote = 3,

        /// <summary>
        /// Received proforma invoice
        /// </summary>
        ReceivedProformaInvoice = 4,
    }
}
