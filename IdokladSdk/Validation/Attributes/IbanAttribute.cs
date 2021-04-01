using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace IdokladSdk.Validation.Attributes
{
    public class IbanAttribute : RegularExpressionAttribute
    {
        public IbanAttribute(string errorMessage)
            : base("^[A-Z]{2}[0-9]{2}[0-9A-Z]{12,30}$")
        {
            ErrorMessage = errorMessage;
        }

        public override bool IsValid(object value)
        {
            return string.IsNullOrEmpty((string)value)
                || Regex.IsMatch((string)value, "^[A-Z]{2}[0-9]{2}[0-9A-Z]{12,30}$")
                     ||
                     Regex.IsMatch(
                         (string)value,
                         "^[A-Z]{2}[0-9]{2}((( [0-9A-Z]{4}){3,6}( [0-9A-Z]{1,3})?)|(( [0-9A-Z]{4}){7}( [0-9A-Z]{1,2})?))$");
        }
    }
}
