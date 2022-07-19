using System;
using System.ComponentModel.DataAnnotations;

namespace IdokladSdk.Validation.Attributes
{
    public class DateGreaterThanOrEqualThanAnotherDateAttribute : ValidationAttribute
    {
        public DateGreaterThanOrEqualThanAnotherDateAttribute(string otherPropertyName)
        {
            OtherPropertyName = otherPropertyName;
        }

        public string OtherPropertyName { get; }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var otherPropertyInfo = validationContext.ObjectType.GetProperty(OtherPropertyName);

            if (otherPropertyInfo?.PropertyType == default(DateTime).GetType())
            {
                var toValidate = (DateTime)value;
                var referenceProperty = (DateTime)otherPropertyInfo.GetValue(validationContext.ObjectInstance, null);
                if (toValidate.CompareTo(referenceProperty) < 0)
                {
                    return new ValidationResult(
                        string.Format($"The {validationContext.MemberName} cannot be earlier than the {OtherPropertyName}"));
                }
            }

            return ValidationResult.Success;
        }
    }
}
