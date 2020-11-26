using System;
using System.ComponentModel.DataAnnotations;
using IdokladSdk.Validation.Attributes;

namespace IdokladSdk.Models.CashRegister
{
    /// <summary>
    /// CashRegisterPostModel.
    /// </summary>
    public class CashRegisterPostModel
    {
        /// <summary>
        /// Gets or sets currency Id.
        /// </summary>
        [Required]
        public int CurrencyId { get; set; }

        /// <summary>
        /// Gets or sets the date when the initial state was set.
        /// </summary>
        [RequiredIfHasValue(nameof(InitialState))]
        [DateTime]
        public DateTime? DateInitialState { get; set; }

        /// <summary>
        /// Gets or sets initial amount of money in the cash register.
        /// </summary>
        [RequiredIfHasValue(nameof(DateInitialState))]
        [Range(0.0, double.MaxValue)]
        public decimal? InitialState { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether cash register is default.
        /// </summary>
        public bool? IsDefault { get; set; }

        /// <summary>
        /// Gets or sets cash register name.
        /// </summary>
        [Required]
        public string Name { get; set; }
    }
}
