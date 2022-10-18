using System;
using System.ComponentModel.DataAnnotations;

namespace IdokladSdk.Validation.Attributes
{
    public class MinValueAttribute : RangeAttribute
    {
        public MinValueAttribute(double minimum)
            : base(minimum, double.MaxValue)
        {
            ErrorMessage = "{0} must be greater than {1}";
        }

        public MinValueAttribute(int minimum)
            : base(minimum, int.MaxValue)
        {
            ErrorMessage = "{0} must be greater than {1}";
        }

        public MinValueAttribute(Type type, string minimum)
            : base(type, minimum, int.MaxValue.ToString())
        {
            ErrorMessage = "{0} must be greater than {1}";
        }
    }
}
