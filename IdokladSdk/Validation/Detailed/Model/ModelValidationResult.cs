using System.Collections.Generic;
using System.Linq;

namespace IdokladSdk.Validation.Detailed.Model
{
    /// <summary>
    /// Result of model validation. <see cref="ModelValidator"/>.
    /// </summary>
    public class ModelValidationResult
    {
        /// <summary>
        /// Gets or sets a value indicating whether model is valid.
        /// </summary>
        public bool IsValid => !InvalidProperties.Any();

        /// <summary>
        /// Gets or sets results of validation of individual properties.
        /// It contains only properties with validation errors.
        /// </summary>
        public Dictionary<string, PropertyValidationResult> InvalidProperties { get; set; }
    }
}
