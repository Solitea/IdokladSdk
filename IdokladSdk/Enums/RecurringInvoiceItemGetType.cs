using System.Runtime.Serialization;

namespace IdokladSdk.Enums
{
    /// <summary>
    /// RecurringInvoiceItemGetType.
    /// </summary>
    public enum RecurringInvoiceItemGetType
    {
        /// <summary>
        /// Normal issued invoice item
        /// </summary>
        [EnumMember(Value = "0")]
        ItemTypeNormal = IssuedInvoiceItemType.ItemTypeNormal,

        /// <summary>
        /// Rounding item
        /// </summary>
        [EnumMember(Value = "1")]
        ItemTypeRound = IssuedInvoiceItemType.ItemTypeRound,

        /// <summary>
        /// Reduced item for accounting of proforma invoices
        /// </summary>
        [EnumMember(Value = "2")]
        ItemTypeReduce = IssuedInvoiceItemType.ItemTypeReduce,
    }
}
