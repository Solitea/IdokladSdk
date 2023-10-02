using System;
using System.ComponentModel.DataAnnotations;
using IdokladSdk.Models.Common.Helpers;

namespace IdokladSdk.Validation.Attributes
{
    public class RangeNullableAttribute : RangeAttribute
    {
        public RangeNullableAttribute(double minimum, double maximum) : base(minimum, maximum)
        {
        }

        public RangeNullableAttribute(int minimum, int maximum) : base(minimum, maximum)
        {
        }

        public RangeNullableAttribute(Type type, string minimum, string maximum) : base(type, minimum, maximum)
        {
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (NullablePropertyHelper.IsNotSetNullableProperty(value))
            {
                return ValidationResult.Success;
            }

            var propertyValue = NullablePropertyHelper.GetValue(value);
            return base.IsValid(propertyValue, validationContext);
        }
    }
}
