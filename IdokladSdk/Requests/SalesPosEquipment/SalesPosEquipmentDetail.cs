using IdokladSdk.Clients;
using IdokladSdk.Models.SalesPosEquipment;
using IdokladSdk.Requests.Core;
using IdokladSdk.Requests.Core.Modifiers.Expand.Structure;

namespace IdokladSdk.Requests.SalesPosEquipment
{
    /// <summary>
    /// Detail of sales pos equipment.
    /// </summary>
    public class SalesPosEquipmentDetail : ExpandableDetail<SalesPosEquipmentDetail, SalesPosEquipmentClient, SalesPosEquipmentGetModel, SalesPosEquipmentExpand>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SalesPosEquipmentDetail"/> class.
        /// </summary>
        /// <param name="id">Sales Pos Equipment id.</param>
        /// <param name="client">Sales Pos Equipment client.</param>
        public SalesPosEquipmentDetail(int id, SalesPosEquipmentClient client)
            : base(id, client)
        {
        }

        internal SalesPosEquipmentDetail(SalesPosEquipmentClient client)
            : base(client)
        {
        }
    }
}
