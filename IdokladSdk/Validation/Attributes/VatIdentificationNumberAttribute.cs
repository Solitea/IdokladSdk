using System.ComponentModel.DataAnnotations;

namespace IdokladSdk.Validation.Attributes
{
    public class VatIdentificationNumberAttribute : RegularExpressionAttribute
    {
        public VatIdentificationNumberAttribute()
            : base("^((CZ){1}[0-9]{8,10}|(SK){1}[0-9]{10})$")
        {
            ErrorMessage = "The VAT ID is not in the right format.";
        }
    }
}
