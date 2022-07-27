﻿using System;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using IdokladSdk.Models.Common;
using IdokladSdk.Models.Common.Extensions;

namespace IdokladSdk.Validation.Attributes
{
    public class CannotEqualAttribute : ValidationAttribute
    {
        public CannotEqualAttribute(object invalidValue, string reason = null)
        {
            InvalidValue = invalidValue;
            Reason = reason;
        }

        public object InvalidValue { get; private set; }

        public string Reason { get; private set; }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            _ = validationContext ?? throw new ArgumentNullException(nameof(validationContext));
            var invalidValue = ConvertInvalidValueToPropertyType(validationContext);
            value = GetValueFromNullableProperty(value);

            if (invalidValue.Equals(value))
            {
                return new ValidationResult($"The {validationContext.DisplayName} field value:{value} is not valid. {Reason}");
            }

            return ValidationResult.Success;
        }

        private dynamic ConvertInvalidValueToPropertyType(ValidationContext validationContext)
        {
            if (InvalidValue != null)
            {
                var type = GetValidatedPropertyType(validationContext);

                if (type != null)
                {
                    return Convert.ChangeType(InvalidValue, type, CultureInfo.InvariantCulture);
                }
            }

            return InvalidValue;
        }

        private dynamic GetValueFromNullableProperty(object value)
        {
            if (value != null)
            {
                var type = value.GetType();
                if (type.IsGenericType && type.GetGenericTypeDefinition() == typeof(NullableProperty<>))
                {
                    return type.GetProperty("Value").GetValue(value);
                }
            }

            return value;
        }

        private Type GetValidatedPropertyType(ValidationContext validationContext)
        {
            var propertyInfo = validationContext?.ObjectType.GetProperty(validationContext?.MemberName) ?? throw new ValidationException();

            if (propertyInfo.PropertyType.IsAnyNullableType(out Type underlyingType))
            {
                return underlyingType;
            }

            return propertyInfo.PropertyType;
        }
    }
}
