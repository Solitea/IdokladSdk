using System;
using System.ComponentModel.DataAnnotations;
using IdokladSdk.Models.Common.Helpers;

namespace IdokladSdk.Validation.Attributes
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = true)]
    public class RequiredIfAttribute : ValidationAttribute
    {
        private readonly RequiredAttribute _innerAttribute = new RequiredAttribute();

        public RequiredIfAttribute(string dependentProperty, object targetValue)
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

            if ((dependentPropertyValue == null && TargetValue == null) ||
                (dependentPropertyValue != null && dependentPropertyValue.Equals(TargetValue)))
            {
                if (!_innerAttribute.IsValid(attributePropertyValue))
                {
                    return new ValidationResult(ErrorMessage, new[] { validationContext.MemberName });
                }
            }

            return null;
        }
    }
}
