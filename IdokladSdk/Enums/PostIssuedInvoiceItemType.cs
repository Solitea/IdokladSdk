namespace Doklad.Shared.Enums.Api
{
    /// <summary>
    /// PostIssuedInvoiceItemType.
    /// </summary>
    public enum PostIssuedInvoiceItemType
    {
        /// <summary>
        /// Normal issued invoice item
        /// </summary>
        ItemTypeNormal = 0,

        /// <summary>
        /// Reduced item for accounted by proforma invoices
        /// </summary>
        ItemTypeReduce = 2
    }
}
