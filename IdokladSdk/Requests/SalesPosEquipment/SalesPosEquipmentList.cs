using IdokladSdk.Clients;
using IdokladSdk.Models.SalesPosEquipment;
using IdokladSdk.Requests.Core;
using IdokladSdk.Requests.Core.Modifiers.Sort.BasicSorts;
using IdokladSdk.Requests.SalesPosEquipment.Filter;

namespace IdokladSdk.Requests.SalesPosEquipment
{
    /// <summary>
    /// List of sales pos equipments.
    /// </summary>
    public class SalesPosEquipmentList : BaseList<SalesPosEquipmentList, SalesPosEquipmentClient, SalesPosEquipmentListGetModel,
        SalesPosEquipmentFilter, IdSort>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SalesPosEquipmentList"/> class.
        /// </summary>
        /// <param name="client">Contact client.</param>
        public SalesPosEquipmentList(SalesPosEquipmentClient client)
            : base(client)
        {
        }
    }
}
