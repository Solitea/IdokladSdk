using System;
using System.ComponentModel.DataAnnotations;
using IdokladSdk.Models.Common.Extensions;

namespace IdokladSdk.Validation.Attributes
{
    public class DateTimeAttribute : RangeNullableAttribute
    {
        public DateTimeAttribute()
            : base(typeof(DateTime), "1753-01-01", "9999-12-31")
        {
            ErrorMessage = "The field {0} is invalid. Must be greater or equal {1}.";
        }

        public DateTimeAttribute(int minimum, int maximum)
            : base(minimum, maximum)
        {
        }

        public DateTimeAttribute(double minimum, double maximum)
            : base(minimum, maximum)
        {
        }

        public DateTimeAttribute(Type type, string minimum, string maximum)
            : base(type, minimum, maximum)
        {
        }

        public override bool IsValid(object value)
        {
            if (value.IsTypeOfNullableProperty(out var type))
            {
                var nullableValue = type.GetValueOfNullableProperty(value);
                if (nullableValue == null)
                {
                    return true;
                }

                return base.IsValid(nullableValue);
            }

            return base.IsValid(value);
        }
    }
}
