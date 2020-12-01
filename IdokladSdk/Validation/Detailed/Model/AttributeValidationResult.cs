using System.ComponentModel.DataAnnotations;
using IdokladSdk.Enums;

namespace IdokladSdk.Validation.Detailed.Model
{
    /// <summary>
    /// Result of validation of single property against single validation attribute.
    /// </summary>
    public class AttributeValidationResult
    {
        private ValidationAttribute _validationAttribute;

        /// <summary>
        /// Gets or sets validation attribute.
        /// Can be used to get attribute parameter (e.g. maximum and minimum string length).
        /// </summary>
        public ValidationAttribute ValidationAttribute
        {
            get => _validationAttribute;
            set
            {
                _validationAttribute = value;
                ValidationType = value.GetValidationType();
            }
        }

        /// <summary>
        /// Gets or sets validation result.
        /// Can be used to obtain original validation message.
        /// </summary>
        public ValidationResult ValidationResult { get; set; }

        /// <summary>
        /// Gets validation type. <see cref="Enums.ValidationType"/>.
        /// </summary>
        public ValidationType ValidationType { get; private set; }
    }
}
