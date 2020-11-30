using System;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using IdokladSdk.Enums;

namespace IdokladSdk.Validation.Attributes
{
    /// <summary>
    /// IdentificationNumberAttribute.
    /// </summary>
    public class IdentificationNumberAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var identNumber = Convert.ToString(value, CultureInfo.InvariantCulture);
            if (string.IsNullOrEmpty(identNumber))
            {
                return ValidationResult.Success;
            }

            var result = IdentificationNumberHelper.IdentificationNumberValidation(identNumber);

            if (result != IdentificationValidationResult.Ok && result != IdentificationValidationResult.NoValue)
            {
                return new ValidationResult("Not valid identification number");
            }

            return ValidationResult.Success;
        }
    }
}
