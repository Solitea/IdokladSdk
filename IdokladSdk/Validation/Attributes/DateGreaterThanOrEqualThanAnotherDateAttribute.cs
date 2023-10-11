using System;
using System.ComponentModel.DataAnnotations;
using System.Reflection;
using IdokladSdk.Models.Common;
using IdokladSdk.Models.Common.Extensions;

namespace IdokladSdk.Validation.Attributes
{
    public class DateGreaterThanOrEqualThanAnotherDateAttribute : ValidationAttribute
    {
        private readonly bool _allowDefualtDate;

        public DateGreaterThanOrEqualThanAnotherDateAttribute(string otherPropertyName, bool allowDefaultDate = false)
        {
            OtherPropertyName = otherPropertyName;
        }

        public string OtherPropertyName { get; }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var propertyInfo = validationContext.ObjectType.GetProperty(validationContext.MemberName);
            var otherPropertyInfo = validationContext.ObjectType.GetProperty(OtherPropertyName);
            var otherPropertyType = GetPropertyType(otherPropertyInfo);

            if (propertyInfo != null)
            {
                if (value == null || (_allowDefualtDate && (DateTime)value == Constants.DefaultDateTime))
                {
                    return ValidationResult.Success;
                }

                var isNullable = Nullable.GetUnderlyingType(propertyInfo.PropertyType) != null;
                if (isNullable && value == null)
                {
                    return ValidationResult.Success;
                }

                if (otherPropertyType != null && value != null)
                {
                    var toValidate = GetValueToValidate(value);
                    var referenceProperty = GetPropertyValue(otherPropertyInfo, validationContext);

                    if (toValidate != DateTime.MinValue && toValidate.CompareTo(referenceProperty) < 0)
                    {
                        return new ValidationResult(
                            string.Format($"The {validationContext.MemberName} cannot be earlier than the {OtherPropertyName}"));
                    }
                }
            }

            return ValidationResult.Success;
        }

        private DateTime GetValueToValidate(object value)
        {
            var type = value.GetType();

            if (type.IsNullableType())
            {
                return ((DateTime?)value).Value;
            }

            if (type.IsNullablePropertyType())
            {
                var propertyValue = (NullableProperty<DateTime>)value;
                return propertyValue.Value.GetValueOrDefault();
            }

            return (DateTime)value;
        }

        private Type GetPropertyType(PropertyInfo propertyInfo)
        {
            if (propertyInfo != null && propertyInfo.PropertyType.IsAnyNullableType(out Type type))
            {
                return type;
            }

            return propertyInfo?.PropertyType;
        }

        private DateTime GetPropertyValue(PropertyInfo propertyInfo, ValidationContext validationContext)
        {
            if (propertyInfo.PropertyType.IsNullableType())
            {
                var propertyValue = (DateTime?)propertyInfo.GetValue(validationContext.ObjectInstance, null);
                return propertyValue.GetValueOrDefault();
            }

            if (propertyInfo.PropertyType.IsNullablePropertyType())
            {
                var propertyValue = (NullableProperty<DateTime>)propertyInfo.GetValue(validationContext.ObjectInstance, null);
                return propertyValue.Value.GetValueOrDefault();
            }

            return (DateTime)propertyInfo.GetValue(validationContext.ObjectInstance, null);
        }
    }
}
