using IdokladSdk.Models.CashRegister;
using IdokladSdk.Models.SalesOffice;

namespace IdokladSdk.Models.SalesPosEquipment
{
    /// <summary>
    /// Model for Get endpoints.
    /// </summary>
    public class SalesPosEquipmentGetModel : SalesPosEquipmentListGetModel
    {
        /// <summary>
        /// Gets or sets CashRegister.
        /// </summary>
        public CashRegisterGetModel CashRegister { get; set; }

        /// <summary>
        /// Gets or sets SalesOffice.
        /// </summary>
        public SalesOfficeGetModel SalesOffice { get; set; }
    }
}
