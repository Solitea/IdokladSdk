using System.ComponentModel.DataAnnotations;
using IbanNet;

namespace IdokladSdk.Validation.Attributes
{
    public class IbanAttribute : ValidationAttribute
    {
        public IbanAttribute(string errorMessage)
        {
            ErrorMessage = errorMessage;
        }

        public override bool IsValid(object value)
        {
            var ibanValidator = new IbanValidator();
            return ibanValidator.Validate((string)value).IsValid;
        }
    }
}
