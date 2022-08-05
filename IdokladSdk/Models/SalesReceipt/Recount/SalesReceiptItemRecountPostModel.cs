using System.ComponentModel.DataAnnotations;
using IdokladSdk.Enums;
using IdokladSdk.Models.Common;

namespace IdokladSdk.Models.SalesReceipt
{
    /// <summary>
    /// SalesReceiptItem Model for Post recount endpoints.
    /// </summary>
    public class SalesReceiptItemRecountPostModel : ItemRecountPostModel
    {
        /// <summary>
        /// Gets or sets item type.
        /// </summary>
        public SalesReceiptItemType ItemType { get; set; }

        /// <summary>
        /// Gets or sets price type.
        /// </summary>
        [Required]
        public PriceTypeWithoutOnlyBase? PriceType { get; set; }
    }
}
