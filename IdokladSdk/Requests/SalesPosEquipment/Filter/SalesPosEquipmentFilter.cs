using IdokladSdk.Enums;
using IdokladSdk.Models.SalesPosEquipment;
using IdokladSdk.Requests.Core.Modifiers.Filters.Common;

namespace IdokladSdk.Requests.SalesPosEquipment.Filter
{
    /// <summary>
    /// Filterable properties of <see cref="SalesPosEquipmentListGetModel"/>.
    /// </summary>
    public class SalesPosEquipmentFilter
    {
        /// <inheritdoc cref="SalesPosEquipmentListGetModel.Id"/>
        public CompareFilterItem<int> Id { get; set; } = new CompareFilterItem<int>(nameof(SalesPosEquipmentListGetModel.Id));

        /// <inheritdoc cref="SalesPosEquipmentListGetModel.SalesPosEquipmentType"/>
        public FilterItem<SalesPosEquipmentType> SalesPosEquipmentType { get; set; }
            = new FilterItem<SalesPosEquipmentType>(nameof(SalesPosEquipmentListGetModel.SalesPosEquipmentType));
    }
}
