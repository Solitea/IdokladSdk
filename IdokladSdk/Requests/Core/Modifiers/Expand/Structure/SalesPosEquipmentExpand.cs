using IdokladSdk.Requests.Core.Modifiers.Expand.Common;

namespace IdokladSdk.Requests.Core.Modifiers.Expand.Structure
{
    /// <summary>
    /// SalesPosEquipmentExpand.
    /// </summary>
    public class SalesPosEquipmentExpand : ExpandableEntity
    {
        /// <summary>
        /// Gets or sets cashRegister.
        /// </summary>
        public CashRegisterExpand CashRegister { get; set; }

        /// <summary>
        /// Gets or sets salesOffice.
        /// </summary>
        public SalesOfficeExpand SalesOffice { get; set; }
    }
}
