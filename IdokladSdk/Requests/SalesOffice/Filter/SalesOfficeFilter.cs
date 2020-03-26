using IdokladSdk.Models.SalesOffice;
using IdokladSdk.Requests.Core.Modifiers.Filters.Common;

namespace IdokladSdk.Requests.SalesOffice.Filter
{
    /// <summary>
    /// Filterable properties of <see cref="SalesOfficeListGetModel"/>.
    /// </summary>
    public class SalesOfficeFilter
    {
        /// <inheritdoc cref="SalesOfficeListGetModel.Id"/>
        public CompareFilterItem<int> Id { get; set; } = new CompareFilterItem<int>(nameof(SalesOfficeListGetModel.Id));
    }
}
