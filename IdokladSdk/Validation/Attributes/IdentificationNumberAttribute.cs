using System;
using System.ComponentModel.DataAnnotations;
using IdokladSdk.Enums;

namespace IdokladSdk.Validation.Attributes
{
    /// <summary>
    /// IdentificationNumberAttribute.
    /// </summary>
    public class IdentificationNumberAttribute : ValidationAttribute
    {
        private readonly string _hasNoIdentificationNumberProperty;

        public IdentificationNumberAttribute(string hasNoIdentificationNumber = null)
        {
            _hasNoIdentificationNumberProperty = hasNoIdentificationNumber;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            _ = validationContext ?? throw new ArgumentNullException(nameof(validationContext));

            var identificationNumber = (string)value;
            if (string.IsNullOrEmpty(_hasNoIdentificationNumberProperty))
            {
                return ValidateWithoutHasNoIdentificationNumberFlag(identificationNumber);
            }

            var hasNoIdentificationNumber = GetHasNoIdentificationNumber(validationContext);
            return ValidateWithHasNoIdentificationNumberFlag(hasNoIdentificationNumber, identificationNumber);
        }

        private bool GetHasNoIdentificationNumber(ValidationContext validationContext)
        {
            var containerType = validationContext.ObjectInstance.GetType();
            var field = containerType.GetProperty(_hasNoIdentificationNumberProperty);
            return (bool?)field?.GetValue(validationContext.ObjectInstance, null) ?? false;
        }

        private ValidationResult ValidateWithHasNoIdentificationNumberFlag(bool hasNoIdentificationNumber, string identificationNumber)
        {
            if (hasNoIdentificationNumber)
            {
                if (!string.IsNullOrEmpty(identificationNumber))
                {
                    return new ValidationResult("Cannot update IdentificationNumber if HasNoIdentificationNumber field is set to true");
                }

                return ValidationResult.Success;
            }

            if (IdentificationNumberValidator.IdentificationNumberValidation(identificationNumber) != IdentificationValidationResult.Ok)
            {
                return new ValidationResult("Not valid identification number");
            }

            return ValidationResult.Success;
        }

        private ValidationResult ValidateWithoutHasNoIdentificationNumberFlag(string identificationNumber)
        {
            if (string.IsNullOrEmpty(identificationNumber))
            {
                return ValidationResult.Success;
            }

            var result = IdentificationNumberValidator.IdentificationNumberValidation(identificationNumber);

            if (result != IdentificationValidationResult.Ok && result != IdentificationValidationResult.NoValue)
            {
                return new ValidationResult("Not valid identification number");
            }

            return ValidationResult.Success;
        }
    }
}
