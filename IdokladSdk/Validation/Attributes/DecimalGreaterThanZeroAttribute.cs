using System;
using System.ComponentModel.DataAnnotations;
using System.Globalization;

namespace IdokladSdk.Validation.Attributes
{
    public class DecimalGreaterThanZeroAttribute : ValidationAttribute
    {
        internal DecimalGreaterThanZeroAttribute()
        {
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            _ = validationContext ?? throw new ArgumentNullException(nameof(validationContext));

            if (value == null)
            {
                return ValidationResult.Success;
            }

            if ((decimal)value <= 0)
            {
                return new ValidationResult(string.Format(CultureInfo.InvariantCulture, ErrorMessageString, validationContext.DisplayName));
            }

            return ValidationResult.Success;
        }
    }
}
