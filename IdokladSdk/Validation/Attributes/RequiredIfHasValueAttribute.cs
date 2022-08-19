using System;
using System.ComponentModel.DataAnnotations;
using System.Reflection;
using IdokladSdk.Models.Common.Extensions;
using IdokladSdk.Models.Common.Helpers;

namespace IdokladSdk.Validation.Attributes
{
    public class RequiredIfHasValueAttribute : ValidationAttribute
    {
        public RequiredIfHasValueAttribute(string dependentProperty)
        {
            DependentProperty = dependentProperty;
        }

        public string DependentProperty { get; set; }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            _ = validationContext ?? throw new ArgumentNullException(nameof(validationContext));

            var containerType = validationContext.ObjectInstance.GetType();
            var dependentPropertyInfo = containerType.GetProperty(DependentProperty);

            if (dependentPropertyInfo != null)
            {
                var dependentPropertyValue = GetDependentPropertyValue(dependentPropertyInfo, validationContext.ObjectInstance);
                var propertyValue = NullablePropertyHelper.GetValue(value);

                if (dependentPropertyValue != null && propertyValue == null)
                {
                    return new ValidationResult(ErrorMessage, new[] { validationContext.MemberName });
                }
            }

            return null;
        }

        private object GetDependentPropertyValue(PropertyInfo dependentPropertyInfo, object objectInstance)
        {
            var type = dependentPropertyInfo.PropertyType;

            if (type.IsNullablePropertyType())
            {
                var nullableProperty = dependentPropertyInfo.GetValue(objectInstance, null);

                return type.GetValueOfNullableProperty(nullableProperty);
            }

            return dependentPropertyInfo.GetValue(objectInstance, null);
        }
    }
}
