using System;
using System.ComponentModel.DataAnnotations;

namespace IdokladSdk.Validation.Attributes
{
    public class NumericSequenceNumberFormatAttribute : ValidationAttribute
    {
        private readonly string _documentNumberProperty;

        public NumericSequenceNumberFormatAttribute(string documentNumberProperty)
        {
            _documentNumberProperty = documentNumberProperty;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            _ = validationContext ?? throw new ArgumentNullException(nameof(validationContext));

            if (value != null)
            {
                var numberFormat = (string)value;
                var documentNumber = GetDocumentNumber(validationContext);
                var isValid = NumericSequenceHelper.HasNumberPlaceholder(numberFormat) &&
                              NumericSequenceHelper.HasRightLength(numberFormat, documentNumber);

                if (!isValid)
                {
                    return new ValidationResult(
                        "Invalid number format. The field must contain the {N} variable meant for increasing the serial number and can have a maximum of 10 characters.");
                }
            }

            return ValidationResult.Success;
        }

        private int GetDocumentNumber(ValidationContext validationContext)
        {
            var documentNumberPropertyInfo = validationContext.ObjectType.GetProperty(_documentNumberProperty);
            return (int?)documentNumberPropertyInfo?.GetValue(validationContext.ObjectInstance) ?? 0;
        }
    }
}
