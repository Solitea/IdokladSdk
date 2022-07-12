using System;
using System.ComponentModel.DataAnnotations;

namespace IdokladSdk.Validation.Attributes
{
    public class DateGreaterThanOrEqualThanAnotherDateAttribute : ValidationAttribute
    {
        private readonly string _otherPropertyName;

        public DateGreaterThanOrEqualThanAnotherDateAttribute(string otherPropertyName)
        {
            _otherPropertyName = otherPropertyName;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var otherPropertyInfo = validationContext.ObjectType.GetProperty(_otherPropertyName);

            if (otherPropertyInfo?.PropertyType == default(DateTime).GetType())
            {
                var toValidate = (DateTime)value;
                var referenceProperty = (DateTime)otherPropertyInfo.GetValue(validationContext.ObjectInstance, null);
                if (toValidate.CompareTo(referenceProperty) < 0)
                {
                    return new ValidationResult(
                        string.Format($"The {validationContext.MemberName} cannot be earlier than the {_otherPropertyName}"));
                }
            }

            return ValidationResult.Success;
        }
    }
}
