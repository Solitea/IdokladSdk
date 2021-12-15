using System.ComponentModel.DataAnnotations;
using IbanNet;

namespace IdokladSdk.Validation.Attributes
{
    public class IbanAttribute : ValidationAttribute
    {
        public IbanAttribute()
        {
            ErrorMessage = "Wrong iban format";
        }

        public override bool IsValid(object value)
        {
            var stringValue = (string)value;
            return string.IsNullOrEmpty(stringValue) || new IbanValidator().Validate(stringValue).IsValid;
        }
    }
}
