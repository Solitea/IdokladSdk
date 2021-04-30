using System;
using System.ComponentModel.DataAnnotations;
using System.Globalization;

namespace IdokladSdk.Validation.Attributes
{
    public class DenyZeroAllowNullAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            _ = validationContext ?? throw new ArgumentNullException(nameof(validationContext));

            var errorMessage = "Property {0} cannot equal to zero.";

            return value != null && Convert.ToInt32(value, CultureInfo.CurrentCulture) == 0
                ? new ValidationResult(string.Format(CultureInfo.CurrentCulture, errorMessage, validationContext.MemberName))
                : ValidationResult.Success;
        }
    }
}
