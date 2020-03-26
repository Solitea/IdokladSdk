using System;

namespace IdokladSdk.Models.ReadOnly.Bank
{
    /// <summary>
    /// BankListGetModel.
    /// </summary>
    public class BankListGetModel : IEntityId
    {
        /// <summary>
        /// Gets or sets iSO_9362 bank code.
        /// </summary>
        public string Code { get; set; }

        /// <summary>
        /// Gets or sets country id.
        /// </summary>
        public int CountryId { get; set; }

        /// <summary>
        /// Gets or sets date when the entity was last changed.
        /// </summary>
        public DateTime DateLastChange { get; set; }

        /// <inheritdoc/>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether indicates whether the bank is no longer active.
        /// </summary>
        public bool IsOutOfDate { get; set; }

        /// <summary>
        /// Gets or sets bank name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets bank code.
        /// </summary>
        public string NumberCode { get; set; }

        /// <summary>
        /// Gets or sets swift code.
        /// </summary>
        public string Swift { get; set; }
    }
}
