using IdokladSdk.Models.RegisteredSale;
using IdokladSdk.Requests.Core.Modifiers.Sort.Common;

namespace IdokladSdk.Requests.RegisteredSale.Sort
{
    /// <summary>
    /// Sortable properties of <see cref=" RegisteredSaleListGetModel"/>.
    /// </summary>
    public class RegisteredSaleSort
    {
        /// <summary>
        /// Gets or sets dateOfIssue.
        /// </summary>
        public SortItem DateOfSale { get; set; } = new SortItem(nameof(RegisteredSaleListGetModel.DateOfSale));

        /// <summary>
        /// Gets or sets id.
        /// </summary>
        public SortItem Id { get; set; } = new SortItem(nameof(RegisteredSaleListGetModel.Id));
    }
}
