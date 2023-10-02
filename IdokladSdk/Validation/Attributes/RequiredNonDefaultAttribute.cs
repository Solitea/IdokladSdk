using System.ComponentModel.DataAnnotations;

namespace IdokladSdk.Validation.Attributes
{
    public class RequiredNonDefaultAttribute : RangeNullableAttribute
    {
        public RequiredNonDefaultAttribute()
            : base(1, int.MaxValue)
        {
        }

        public override string FormatErrorMessage(string name)
        {
            return $"The {name} field is required";
        }
    }
}
