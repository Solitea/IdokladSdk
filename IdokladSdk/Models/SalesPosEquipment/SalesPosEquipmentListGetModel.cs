using IdokladSdk.Enums;
using IdokladSdk.Models.Common;

namespace IdokladSdk.Models.SalesPosEquipment
{
    /// <summary>
    /// Model for List endpoints.
    /// </summary>
    public class SalesPosEquipmentListGetModel : IEntityId
    {
        /// <summary>
        /// Gets or sets cash register id.
        /// </summary>
        public int? CashRegisterId { get; set; }

        /// <summary>
        /// Gets or sets sales office designation.
        /// </summary>
        public string Designation { get; set; }

        /// <inheritdoc/>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether flag determining whether the equipment is registered for EET.
        /// </summary>
        public bool IsRegisteredEet { get; set; }

        /// <summary>
        /// Gets or sets additional information about the entity.
        /// </summary>
        public Metadata Metadata { get; set; }

        /// <summary>
        /// Gets or sets pOS equipment name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets id prodejního místa.
        /// </summary>
        public int? SalesOfficeId { get; set; }

        /// <summary>
        /// Gets or sets typ prodejního zařízení.
        /// </summary>
        /// <summary>
        /// POS equipment type.
        /// </summary>
        public SalesPosEquipmentType SalesPosEquipmentType { get; set; }
    }
}
