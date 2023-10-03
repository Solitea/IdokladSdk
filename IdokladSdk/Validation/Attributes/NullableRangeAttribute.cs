using System;
using System.ComponentModel.DataAnnotations;
using IdokladSdk.Models.Common.Extensions;

namespace IdokladSdk.Validation.Attributes
{
    internal class NullableRangeAttribute : RangeAttribute
    {
        public NullableRangeAttribute(double minimum, double maximum)
            : base(minimum, maximum)
        {
        }

        public NullableRangeAttribute(int minimum, int maximum)
             : base(minimum, maximum)
        {
        }

        public NullableRangeAttribute(Type type, string minimum, string maximum)
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
