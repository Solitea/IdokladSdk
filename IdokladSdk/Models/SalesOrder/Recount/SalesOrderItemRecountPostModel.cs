using System.ComponentModel.DataAnnotations;
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

        /// <summary>
        /// Gets or sets price type.
        /// </summary>
        [Required]
        public PriceType? PriceType { get; set; }
    }
}
