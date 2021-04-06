using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace IdokladSdk.Validation.Attributes
{
    public class NotEmptyStringAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            return value == null || Regex.IsMatch((string)value, @"^\s*$");
        }
    }
}
