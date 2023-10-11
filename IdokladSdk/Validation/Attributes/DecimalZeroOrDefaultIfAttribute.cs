using System;
using System.ComponentModel.DataAnnotations;
using IdokladSdk.Models.Common.Helpers;

namespace IdokladSdk.Validation.Attributes
{
    public class DecimalZeroOrDefaultIfAttribute : ValidationAttribute
    {
        public DecimalZeroOrDefaultIfAttribute(string dependentProperty, object targetValue)
        {
            DependentProperty = dependentProperty;
            TargetValue = targetValue;
        }

        public string DependentProperty { get; set; }

        public object TargetValue { get; set; }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            _ = validationContext ?? throw new ArgumentNullException(nameof(validationContext));

            if (NullablePropertyHelper.IsNotSetNullableProperty(value))
            {
                return ValidationResult.Success;
            }

            var attributePropertyValue = NullablePropertyHelper.GetValue(value);
            var dependentPropertyValue = NullablePropertyHelper.GetDependentPropertyValue(validationContext, DependentProperty);

            if (attributePropertyValue != null
                && (decimal)attributePropertyValue != 0.0m
                && dependentPropertyValue != null && dependentPropertyValue.Equals(TargetValue))
            {
                return new ValidationResult(
                    $"The field {validationContext.MemberName} must be zero or null if {DependentProperty} is {TargetValue}",
                    new[] { validationContext.MemberName });
            }

            return ValidationResult.Success;
        }
    }
}
