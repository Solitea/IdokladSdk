using System.ComponentModel.DataAnnotations;
using IdokladSdk.Enums;
using IdokladSdk.Models.Common;

namespace IdokladSdk.Models.BankStatement.Recount
{
    /// <summary>
    /// BankStatementItemRecountPostModel.
    /// </summary>
    public class BankStatementItemRecountPostModel : ItemRecountPostModel
    {
        /// <summary>
        /// Gets or sets Custom VAT rate.
        /// </summary>
        public decimal? CustomVat { get; set; }

        /// <summary>
        /// Gets or sets price type.
        /// </summary>
        [Required]
        public PriceType? PriceType { get; set; }
    }
}
