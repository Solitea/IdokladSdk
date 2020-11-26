using System;
using System.ComponentModel.DataAnnotations;
using IdokladSdk.Validation.Attributes;

namespace IdokladSdk.Models.CashRegister
{
    /// <summary>
    /// CashRegisterPatchModel.
    /// </summary>
    public class CashRegisterPatchModel : IEntityId
    {
        /// <summary>
        /// Gets or sets currency Id.
        /// </summary>
        public int? CurrencyId { get; set; }

        /// <summary>
        /// Gets or sets the date when the initial state was set.
        /// </summary>
        [RequiredIfHasValue(nameof(InitialState))]
        [DateTime]
        public DateTime? DateInitialState { get; set; }

        /// <inheritdoc/>
        [Required]
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets initial amount of money in the cash register.
        /// </summary>
        [Range(0.0, double.MaxValue)]
        [RequiredIfHasValue(nameof(DateInitialState))]
        public decimal? InitialState { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether cash register is default.
        /// </summary>
        public bool? IsDefault { get; set; }

        /// <summary>
        /// Gets or sets cash register name.
        /// </summary>
        public string Name { get; set; }
    }
}
