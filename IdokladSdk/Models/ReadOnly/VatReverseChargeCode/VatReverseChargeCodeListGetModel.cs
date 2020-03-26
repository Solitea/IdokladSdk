using System;

namespace IdokladSdk.Models.ReadOnly.VatReverseChargeCode
{
    /// <summary>
    /// VatReverseChargeCodeListGetModel.
    /// </summary>
    public class VatReverseChargeCodeListGetModel : IEntityId
    {
        /// <summary>
        /// Gets or sets code value.
        /// </summary>
        public string Code { get; set; }

        /// <summary>
        /// Gets or sets date when the entity was created.
        /// </summary>
        public DateTime DateCreated { get; set; }

        /// <summary>
        /// Gets or sets date when the entity was last changed.
        /// </summary>
        public DateTime DateLastChange { get; set; }

        /// <summary>
        /// Gets or sets date since the code is valid.
        /// </summary>
        public DateTime DateValidityFrom { get; set; }

        /// <summary>
        /// Gets or sets date until the code is valid.
        /// </summary>
        public DateTime DateValidityTo { get; set; }

        /// <inheritdoc/>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets description of the code.
        /// </summary>
        public string Name { get; set; }
    }
}
