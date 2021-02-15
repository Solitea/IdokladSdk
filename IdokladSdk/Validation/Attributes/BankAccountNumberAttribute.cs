using System.ComponentModel.DataAnnotations;

namespace IdokladSdk.Validation.Attributes
{
    public class BankAccountNumberAttribute : RegularExpressionAttribute
    {
        public BankAccountNumberAttribute(string errorMessage)
            : base(@"^(\d*|(\d+-\d+))$")
        {
            ErrorMessage = errorMessage;
        }
    }
}
