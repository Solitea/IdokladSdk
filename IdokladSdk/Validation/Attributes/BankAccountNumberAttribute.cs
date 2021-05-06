using System.ComponentModel.DataAnnotations;

namespace IdokladSdk.Validation.Attributes
{
    public class BankAccountNumberAttribute : RegularExpressionAttribute
    {
        public BankAccountNumberAttribute()
            : base(@"^(\d*|(\d+-\d+))$")
        {
            ErrorMessage = "Bank account number is in wrong format.";
        }
    }
}
