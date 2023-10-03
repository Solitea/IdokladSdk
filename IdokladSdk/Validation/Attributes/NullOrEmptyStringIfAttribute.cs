using System.ComponentModel.DataAnnotations;
using IdokladSdk.Models.Common.Helpers;
using IdokladSdk.Requests.Core.Extensions;

namespace IdokladSdk.Validation.Attributes
{
    public class NullOrEmptyStringIfAttribute : ValidationAttribute
    {
        public NullOrEmptyStringIfAttribute(string dependentProperty, object targetValue)
        {
            DependentProperty = dependentProperty;
            TargetValue = targetValue;
        }

        private string DependentProperty { get; }

        private object TargetValue { get; }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var dependentPropertyValue =
                NullablePropertyHelper.GetDependentPropertyValue(validationContext, DependentProperty);

            if (
                dependentPropertyValue != null
                && dependentPropertyValue.Equals(TargetValue)
                && ((string)value).IsNotNullOrEmpty())
            {
                return new ValidationResult(
                    $"The field {validationContext.MemberName} must be null or empty if {DependentProperty} is {TargetValue}",
                    new[] { validationContext.MemberName });
            }

            return ValidationResult.Success;
        }
    }
}
