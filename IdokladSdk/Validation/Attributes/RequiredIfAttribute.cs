using System;
using System.ComponentModel.DataAnnotations;

namespace IdokladSdk.Validation.Attributes
{
    /// <summary>
    /// RequiredIfAttribute.
    /// </summary>
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = true)]
    internal class RequiredIfAttribute : ValidationAttribute
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
            var containerType = validationContext.ObjectInstance.GetType();
            var field = containerType.GetProperty(DependentProperty);

            if (field != null)
            {
                var dependentvalue = field.GetValue(validationContext.ObjectInstance, null);

                if ((dependentvalue == null && TargetValue == null) ||
                    (dependentvalue != null && dependentvalue.Equals(TargetValue)))
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
