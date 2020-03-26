using System.ComponentModel.DataAnnotations;
using System.Globalization;

namespace IdokladSdk.Validation.Attributes
{
    internal class DecimalGreaterThanZeroAttribute : ValidationAttribute
    {
        internal DecimalGreaterThanZeroAttribute()
        {
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
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
