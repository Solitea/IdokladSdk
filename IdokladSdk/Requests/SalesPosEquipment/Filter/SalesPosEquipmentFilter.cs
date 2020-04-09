using IdokladSdk.Enums;
using IdokladSdk.Models.SalesPosEquipment;
using IdokladSdk.Requests.Core.Modifiers.Filters;
using IdokladSdk.Requests.Core.Modifiers.Filters.Common;

namespace IdokladSdk.Requests.SalesPosEquipment.Filter
{
    /// <summary>
    /// Filterable properties of <see cref="SalesPosEquipmentListGetModel"/>.
    /// </summary>
    public class SalesPosEquipmentFilter : IdFilter
    {
        /// <inheritdoc cref="SalesPosEquipmentListGetModel.SalesPosEquipmentType"/>
        public FilterItem<SalesPosEquipmentType> SalesPosEquipmentType { get; set; }
            = new FilterItem<SalesPosEquipmentType>(nameof(SalesPosEquipmentListGetModel.SalesPosEquipmentType));
    }
}
