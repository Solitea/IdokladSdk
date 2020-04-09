using IdokladSdk.Models.RegisteredSale;
using IdokladSdk.Requests.Core.Modifiers.Sort.BasicSorts;
using IdokladSdk.Requests.Core.Modifiers.Sort.Common;

namespace IdokladSdk.Requests.RegisteredSale.Sort
{
    /// <summary>
    /// Sortable properties of <see cref=" RegisteredSaleListGetModel"/>.
    /// </summary>
    public class RegisteredSaleSort : IdSort
    {
        /// <inheritdoc cref="RegisteredSaleListGetModel.DateOfSale"/>
        public SortItem DateOfSale { get; set; } = new SortItem(nameof(RegisteredSaleListGetModel.DateOfSale));
    }
}
