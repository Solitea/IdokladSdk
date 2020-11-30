using System.ComponentModel.DataAnnotations;

namespace IdokladSdk.Validation.Attributes
{
    public class NotEmptyStringAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            return value == null || !string.IsNullOrEmpty((string)value);
        }
    }
}
