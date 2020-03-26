using IdokladSdk.Enums;
using IdokladSdk.Models.Common;

namespace IdokladSdk.Models.SalesOrder
{
    /// <summary>
    /// SalesOrderItem Model for Post recount endpoints.
    /// </summary>
    public class SalesOrderItemRecountPostModel : ItemRecountPostModel
    {
        /// <summary>
        /// Gets or sets item type.
        /// </summary>
        public SalesOrderItemType ItemType { get; set; }
    }
}
