﻿using System;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using IdokladSdk.Models.Common;
using IdokladSdk.Models.Common.Helpers;

namespace IdokladSdk.Validation.Attributes
{
    public class DateGreaterOrEqualThanAttribute : ValidationAttribute
    {
        public DateGreaterOrEqualThanAttribute(string dateTime, bool allowNull = false)
        {
            MinDateTime = DateTime.Parse(dateTime, CultureInfo.InvariantCulture);
            AllowNull = allowNull;
        }

        public bool AllowNull { get; private set; }

        public DateTime MinDateTime { get; private set; }

        public override bool IsValid(object value)
        {
            if (value is NullableProperty<DateTime> property && !property.IsSet)
            {
                return true;
            }

            var propertyValue = NullablePropertyHelper.GetValue(value);

            if (propertyValue == null && AllowNull)
            {
                return true;
            }

            if (propertyValue != null)
            {
                var dateTime = (DateTime)propertyValue;
                if (dateTime >= MinDateTime)
                {
                    return true;
                }
            }

            return false;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            _ = validationContext ?? throw new ArgumentNullException(nameof(validationContext));

            if (value is NullableProperty<DateTime> property && !property.IsSet)
            {
                return ValidationResult.Success;
            }

            var propertyValue = NullablePropertyHelper.GetValue(value);

            if (propertyValue == null && AllowNull)
            {
                return ValidationResult.Success;
            }

            if (propertyValue != null)
            {
                var dateTime = (DateTime)propertyValue;
                if (dateTime >= MinDateTime)
                {
                    return ValidationResult.Success;
                }
            }

            var propertyName = validationContext.MemberName;

            return new ValidationResult(
                $"The field {propertyName} is invalid. Must be greater or equal {MinDateTime}");
        }
    }
}
