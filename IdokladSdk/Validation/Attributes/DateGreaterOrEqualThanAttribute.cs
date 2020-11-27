using System;
using System.ComponentModel.DataAnnotations;
using System.Globalization;

namespace IdokladSdk.Validation.Attributes
{
    public class DateGreaterOrEqualThanAttribute : ValidationAttribute
    {
        private readonly bool _allowNull;
        private readonly DateTime _minDateTime;

        public DateGreaterOrEqualThanAttribute(string dateTime, bool allowNull = false)
        {
            _minDateTime = DateTime.Parse(dateTime, CultureInfo.InvariantCulture);
            _allowNull = allowNull;
        }

        public override bool IsValid(object value)
        {
            if (value == null && _allowNull)
            {
                return true;
            }

            if (value != null)
            {
                var dateTime = (DateTime)value;
                if (dateTime >= _minDateTime)
                {
                    return true;
                }
            }

            return false;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value == null && _allowNull)
            {
                return ValidationResult.Success;
            }

            if (value != null)
            {
                var dateTime = (DateTime)value;
                if (dateTime >= _minDateTime)
                {
                    return ValidationResult.Success;
                }
            }

            var propertyName = validationContext.MemberName;

            return new ValidationResult(
                $"The field {propertyName} is invalid. Must be greater or equal {_minDateTime}");
        }
    }
}
