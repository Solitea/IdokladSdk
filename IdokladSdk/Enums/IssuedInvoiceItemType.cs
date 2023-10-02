namespace IdokladSdk.Enums
{
    /// <summary>
    /// IssuedInvoiceItemType.
    /// </summary>
    public enum IssuedInvoiceItemType
    {
        /// <summary>
        /// Normal issued invoice item
        /// </summary>
        ItemTypeNormal = 0,

        /// <summary>
        /// Rounding item
        /// </summary>
        ItemTypeRound = 1,

        /// <summary>
        /// Reduced item for accounting of proforma invoices
        /// </summary>
        ItemTypeReduce = 2,

        /// <summary>
        /// Discount item
        /// </summary>
        ItemTypeDiscount = 3
    }
}
