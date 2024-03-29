﻿using System;
using System.ComponentModel.DataAnnotations;
using IdokladSdk.Models.Base;
using IdokladSdk.Models.Common;
using IdokladSdk.Validation.Attributes;

namespace IdokladSdk.Models.CashRegister
{
    /// <summary>
    /// CashRegisterPatchModel.
    /// </summary>
    public class CashRegisterPatchModel : ValidatableModel, IEntityId
    {
        /// <summary>
        /// Gets or sets currency Id.
        /// </summary>
        [NullableForeignKey]
        public int? CurrencyId { get; set; }

        /// <summary>
        /// Gets or sets the date when the initial state was set.
        /// </summary>
        [RequiredIfHasValue(nameof(InitialState))]
        [DateTime]
        public NullableProperty<DateTime> DateInitialState { get; set; }

        /// <inheritdoc/>
        [Required]
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets initial amount of money in the cash register.
        /// </summary>
        [NullableRange(0.0, double.MaxValue)]
        [RequiredIfHasValue(nameof(DateInitialState))]
        public NullableProperty<decimal> InitialState { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether cash register is default.
        /// </summary>
        public bool? IsDefault { get; set; }

        /// <summary>
        /// Gets or sets cash register name.
        /// </summary>
        [StringLength(100)]
        [NotEmptyString]
        public string Name { get; set; }
    }
}
