using System;
using System.ComponentModel.DataAnnotations;
using IdokladSdk.Models.Common.Helpers;

namespace IdokladSdk.Validation.Attributes
{
    public class CannotEqualIfAttribute : ValidationAttribute
    {
        public CannotEqualIfAttribute(object invalidValue, string dependentProperty, object targetValue)
        {
            InvalidValue = invalidValue;
            DependentProperty = dependentProperty;
            TargetValue = targetValue;
        }

        private string DependentProperty { get; }

        private object InvalidValue { get; }

        private object TargetValue { get; }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (NullablePropertyHelper.IsNotSetNullableProperty(value))
            {
                return ValidationResult.Success;
            }

            var dependentPropertyValue =
                NullablePropertyHelper.GetDependentPropertyValue(validationContext, DependentProperty);
            var attributePropertyValue = NullablePropertyHelper.GetValue(value);

            if (
                dependentPropertyValue != null 
                && attributePropertyValue != null
                && dependentPropertyValue.Equals(TargetValue)
                && IsEqual(attributePropertyValue, InvalidValue))
            {
                return new ValidationResult(
                    $"The field {validationContext.MemberName} cannot be {InvalidValue} if {DependentProperty} is {TargetValue}",
                    new[] { validationContext.MemberName });
            }

            return ValidationResult.Success;
        }

        private bool IsEqual(object value, object invalidValue)
        {
            if (value?.GetType() == typeof(decimal))
            {
                return decimal.Compare((decimal)value, Convert.ToDecimal(invalidValue)) == 0;
            }

            return object.Equals(value, invalidValue);
        }
    }
}
