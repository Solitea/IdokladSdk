using System;
using System.ComponentModel.DataAnnotations;
using IdokladSdk.Models.Common.Helpers;

namespace IdokladSdk.Validation.Attributes
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = true)]
    public class NullIfAttribute : ValidationAttribute
    {
        public NullIfAttribute(string dependentProperty, object targetValue)
        {
            DependentProperty = dependentProperty;
            TargetValue = targetValue;
        }

        private string DependentProperty { get; }

        private object TargetValue { get; }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (NullablePropertyHelper.IsNotSetNullableProperty(value))
            {
                return ValidationResult.Success;
            }

            var dependentPropertyValue =
                NullablePropertyHelper.GetDependentPropertyValue(validationContext, DependentProperty);

            var propertyValue = NullablePropertyHelper.GetValue(value);

            if (
                dependentPropertyValue != null
                && dependentPropertyValue.Equals(TargetValue)
                && propertyValue != null)
            {
                return new ValidationResult(
                    $"The field {validationContext.MemberName} cannot be set if {DependentProperty} is {TargetValue}",
                    new[] { validationContext.MemberName });
            }

            return ValidationResult.Success;
        }
    }
}
