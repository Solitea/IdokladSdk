using System;
using System.ComponentModel.DataAnnotations;

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

            var containerType = validationContext.ObjectInstance.GetType();
            var field = containerType.GetProperty(DependentProperty);

            if (field != null)
            {
                var dependentValue = field.GetValue(validationContext.ObjectInstance, null);

                if ((dependentValue == null && TargetValue == null) ||
                    (dependentValue != null && dependentValue.Equals(TargetValue)))
                {
                    if (!_innerAttribute.IsValid(value))
                    {
                        return new ValidationResult(ErrorMessage, new[] { validationContext.MemberName });
                    }
                }
            }

            return null;
        }
    }
}
