namespace IdokladSdk.Enums
{
    /// <summary>
    /// IssuedDocumentTemplateItemGetType.
    /// </summary>
    public enum IssuedDocumentTemplateItemGetType
    {
        /// <summary>
        /// Normal issued invoice item
        /// </summary>
        ItemTypeNormal = IssuedInvoiceItemType.ItemTypeNormal,

        /// <summary>
        /// Rounding item
        /// </summary>
        ItemTypeRound = IssuedInvoiceItemType.ItemTypeRound,

        /// <summary>
        /// Reduced item for accounting of proforma invoices
        /// </summary>
        ItemTypeReduce = IssuedInvoiceItemType.ItemTypeReduce,
    }
}
