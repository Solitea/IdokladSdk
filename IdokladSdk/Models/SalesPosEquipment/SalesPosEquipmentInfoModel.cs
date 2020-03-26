using IdokladSdk.Models.NumericSequence;

namespace IdokladSdk.Models.SalesPosEquipment
{
    /// <summary>
    /// Model for Get Info endpoints.
    /// </summary>
    public class SalesPosEquipmentInfoModel : IEntityId
    {
        /// <summary>
        /// Gets or sets Sales office designation.
        /// </summary>
        public string Designation { get; set; }

        /// <inheritdoc/>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets POS equipment name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets Information about the associated numeric sequence.
        /// </summary>
        public NumericSequenceGetModel NumericSequence { get; set; }

        /// <summary>
        /// Gets or sets Sales office Id.
        /// </summary>
        public int? SalesOfficeId { get; set; }
    }
}
