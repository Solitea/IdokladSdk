using System;
using System.ComponentModel.DataAnnotations;
using IdokladSdk.Models.Common;

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
            if (value != null)
            {
                var type = value.GetType();
                if (type.IsGenericType && type.GetGenericTypeDefinition() == typeof(NullableProperty<>))
                {
                    var nullableValue = type.GetProperty("Value").GetValue(value);
                    if (nullableValue == null)
                    {
                        return true;
                    }
                }
            }

            return base.IsValid(value);
        }
    }
}
