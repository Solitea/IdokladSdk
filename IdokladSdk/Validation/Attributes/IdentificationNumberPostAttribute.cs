using System;
using System.ComponentModel.DataAnnotations;
using IdokladSdk.Enums;

namespace IdokladSdk.Validation.Attributes
{
    /// <summary>
    /// IdentificationNumberPostAttribute.
    /// </summary>
    public class IdentificationNumberPostAttribute : ValidationAttribute
    {
        private readonly string _hasNoIdentificationNumberProperty;

        /// <summary>
        /// Initializes a new instance of the <see cref="IdentificationNumberPostAttribute"/> class.
        /// </summary>
        /// <param name="hasNoIdentificationNumber">hasNoIdentificationNumber field name.</param>
        public IdentificationNumberPostAttribute(string hasNoIdentificationNumber)
        {
            _hasNoIdentificationNumberProperty = hasNoIdentificationNumber;
        }

        /// <summary>
        /// Validate Identification number.
        /// </summary>
        /// <param name="value">value.</param>
        /// <param name="validationContext">Validation context.</param>
        /// <returns>Validation result.</returns>
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            _ = validationContext ?? throw new ArgumentNullException(nameof(validationContext));

            var identificationNumber = (string)value;
            var hasNoIdentificationNumber = GetHasNoIdentificationNumber(validationContext);

            if (identificationNumber != string.Empty && hasNoIdentificationNumber)
            {
                return new ValidationResult(
                    "Cannot update IdentificationNumber if HasNoIdentificationNumber field is set to true");
            }

            if (!hasNoIdentificationNumber)
            {
                if (identificationNumber == string.Empty)
                {
                    return new ValidationResult(
                        "IdentificationNumber is required if HasNoIdentificationNumber field is set to false");
                }

                if (IdentificationNumberValidator.IdentificationNumberValidation(identificationNumber) !=
                    IdentificationValidationResult.Ok)
                {
                    return new ValidationResult("IdentificationNumber is not valid");
                }
            }

            return ValidationResult.Success;
        }

        private bool GetHasNoIdentificationNumber(ValidationContext validationContext)
        {
            var containerType = validationContext.ObjectInstance.GetType();
            var field = containerType.GetProperty(_hasNoIdentificationNumberProperty);
            return (bool)(field?.GetValue(validationContext.ObjectInstance, null) ?? false);
        }
    }
}
