using System;

namespace IdokladSdk.Models.ReadOnly.PaymentOption
{
    /// <summary>
    /// PaymentOptionListGetModel.
    /// </summary>
    public class PaymentOptionListGetModel : IEntityId
    {
        /// <summary>
        /// Gets or sets payment option code.
        /// </summary>
        public string Code { get; set; }

        /// <summary>
        /// Gets or sets date when the entity was last changed.
        /// </summary>
        public DateTime DateLastChange { get; set; }

        /// <inheritdoc/>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether payment option is default.
        /// </summary>
        public bool IsDefault { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether payment option is rounded.
        /// </summary>
        public bool IsRounded { get; set; }

        /// <summary>
        /// Gets or sets payment option name.
        /// </summary>
        public string Name { get; set; }
    }
}
