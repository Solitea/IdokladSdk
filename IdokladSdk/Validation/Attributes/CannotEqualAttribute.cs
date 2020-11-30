using System;
using System.ComponentModel.DataAnnotations;

namespace IdokladSdk.Validation.Attributes
{
    public class CannotEqualAttribute : ValidationAttribute
    {
        private readonly object _invalidValue;

        private readonly string _reason;

        public CannotEqualAttribute(object invalidValue, string reason = null)
        {
            _invalidValue = invalidValue;
            _reason = reason;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            _ = validationContext ?? throw new ArgumentNullException(nameof(validationContext));

            if (_invalidValue.Equals(value))
            {
                return new ValidationResult($"The {validationContext.DisplayName} field value:{value} is not valid. {_reason}");
            }

            return ValidationResult.Success;
        }
    }
}
