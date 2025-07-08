using System;
using System.ComponentModel.DataAnnotations;

namespace IdokladSdk.Validation.Attributes
{
    /// <summary>
    /// Validation attribute ensuring that DateTime property is in UTC format.
    /// </summary>
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
    public class UtcDateTimeAttribute : ValidationAttribute
    {
        public UtcDateTimeAttribute()
            : base("DateTime must be in UTC format.")
        {
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value == null)
            {
                return ValidationResult.Success;
            }

            // Check if the value is a DateTime or nullable DateTime.
            if (value is DateTime dateTime && dateTime.Kind != DateTimeKind.Utc)
            {
                return new ValidationResult(ErrorMessage);
            }

            return ValidationResult.Success;
        }
    }
}
