using IdokladSdk.Enums;
using IdokladSdk.Models.Base;

namespace IdokladSdk.Models.Batch
{
    /// <summary>
    /// Model for updating exported status of entities.
    /// </summary>
    public class UpdateExportedModel : ValidatableModel, IEntityId
    {
        /// <inheritdoc/>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets entity type.
        /// </summary>
        public ExportableEntityType EntityType { get; set; }

        /// <summary>
        /// Gets or sets export to another accounting software indication. (It is recommended to use only one external accounting software beside iDoklad.).
        /// </summary>
        public ExportedState Exported { get; set; }
    }
}
