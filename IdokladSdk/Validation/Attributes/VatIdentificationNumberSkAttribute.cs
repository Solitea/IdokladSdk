using System.ComponentModel.DataAnnotations;
using IdokladSdk.Validation;

namespace IdokladSdk.Validation.Attributes
{
    /// <summary>
    /// Validates a Slovak VAT identification number.
    /// </summary>
    public class VatIdentificationNumberSkAttribute : ValidationAttribute
    {
        public VatIdentificationNumberSkAttribute()
        {
            ErrorMessage = "The VAT ID is not in the right format.";
        }

        public override bool IsValid(object value)
        {
            return IdentificationNumberValidator.IsVatIdentificationNumberSkValid((string)value);
        }
    }
}
