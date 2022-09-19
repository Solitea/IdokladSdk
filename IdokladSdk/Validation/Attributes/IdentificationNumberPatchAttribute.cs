using System;
using System.ComponentModel.DataAnnotations;
using IdokladSdk.Enums;

namespace IdokladSdk.Validation.Attributes
{
    public class IdentificationNumberPatchAttribute : ValidationAttribute
    {
        private readonly string _hasNoIdentificationNumberProperty;

        public IdentificationNumberPatchAttribute(string hasNoIdentificationNumber)
        {
            _hasNoIdentificationNumberProperty = hasNoIdentificationNumber;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            _ = validationContext ?? throw new ArgumentNullException(nameof(validationContext));

            var identificationNumber = (string)value;
            var hasNoIdentificationNumber = GetHasNoIdentificationNumber(validationContext);

            if ((identificationNumber != null && hasNoIdentificationNumber == null) ||
                (identificationNumber == null && hasNoIdentificationNumber != null))
            {
                return new ValidationResult("Both or neither fields HasNoIdentificationNumber and IdentificationNumber must be filled");
            }

            if (identificationNumber != null)
            {
                if (identificationNumber != string.Empty && hasNoIdentificationNumber.Value)
                {
                    return new ValidationResult("Cannot update IdentificationNumber if HasNoIdentificationNumber field is set to true");
                }

                if (!hasNoIdentificationNumber.Value)
                {
                    if (identificationNumber == string.Empty)
                    {
                        return new ValidationResult("IdentificationNumber is required if HasNoIdentificationNumber field is set to false");
                    }

                    if (IdentificationNumberValidator.IdentificationNumberValidation(identificationNumber) != IdentificationValidationResult.Ok)
                    {
                        return new ValidationResult("IdentificationNumber is not valid");
                    }
                }
            }

            return ValidationResult.Success;
        }

        private bool? GetHasNoIdentificationNumber(ValidationContext validationContext)
        {
            var containerType = validationContext.ObjectInstance.GetType();
            var field = containerType.GetProperty(_hasNoIdentificationNumberProperty);
            return (bool?)field?.GetValue(validationContext.ObjectInstance, null);
        }
    }
}
