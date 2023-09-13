using System;
using System.ComponentModel.DataAnnotations;
using IdokladSdk.Models.Common;
using IdokladSdk.Models.Common.Helpers;

namespace IdokladSdk.Validation.Attributes
{
    public class DateGreaterOrEqualThanTodayAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value is NullableProperty<DateTime> property && !property.IsSet)
            {
                return ValidationResult.Success;
            }

            var propertyValue = NullablePropertyHelper.GetValue(value);
            if (propertyValue == null || ((DateTime)propertyValue).Date < DateTime.UtcNow.Date)
            {
                return new ValidationResult(
                    $"The field {validationContext.MemberName} is invalid. Must be greater or equal than today",
                    new[] { validationContext.MemberName });
            }

            return ValidationResult.Success;
        }
    }
}
