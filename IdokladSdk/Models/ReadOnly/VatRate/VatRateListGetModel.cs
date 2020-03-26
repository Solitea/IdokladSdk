using System;
using IdokladSdk.Enums;

namespace IdokladSdk.Models.ReadOnly.VatRate
{
    /// <summary>
    /// VatRateListGetModel.
    /// </summary>
    public class VatRateListGetModel : IEntityId
    {
        /// <summary>
        /// Gets or sets country id.
        /// </summary>
        public int CountryId { get; set; }

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
        /// Gets or sets VAT rate name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets VAT rate.
        /// </summary>
        public decimal Rate { get; set; }

        /// <summary>
        /// Gets or sets VAT rate type.
        /// </summary>
        public VatRateType RateType { get; set; }
    }
}
