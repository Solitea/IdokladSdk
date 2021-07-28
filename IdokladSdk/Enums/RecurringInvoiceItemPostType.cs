using System.Runtime.Serialization;

namespace IdokladSdk.Enums
{
    /// <summary>
    /// RecurringInvoiceItemPostType.
    /// </summary>
    public enum RecurringInvoiceItemPostType
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
        ItemTypeRound = IssuedInvoiceItemType.ItemTypeRound
    }
}
