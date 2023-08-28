using System.ComponentModel.DataAnnotations;
using IdokladSdk.Enums;
using IdokladSdk.Models.Common;
using IdokladSdk.Models.Common.Helpers;

namespace IdokladSdk.Validation.Attributes
{
    public class CopyCountEndOnRecurringInvoiceAttribute : ValidationAttribute
    {
        public CopyCountEndOnRecurringInvoiceAttribute(string typeOfEnd)
        {
            TypeOfEnd = typeOfEnd;
        }

        private string TypeOfEnd { get; }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value is NullableProperty<int> property && !property.IsSet)
            {
                return ValidationResult.Success;
            }

            var copyCountEnd = NullablePropertyHelper.GetValue(value);
            var typeOfEnd = GetRecurrenceTypeOfEnd(validationContext);
            if (typeOfEnd == RecurrenceTypeOfEnd.AfterNumberCreated)
            {
                if (copyCountEnd == null)
                {
                    return new ValidationResult(
                        $"The field {validationContext.MemberName} is required for {nameof(RecurrenceTypeOfEnd)}.{RecurrenceTypeOfEnd.AfterNumberCreated}",
                        new[] { validationContext.MemberName });
                }
            }

            return ValidationResult.Success;
        }

        private RecurrenceTypeOfEnd? GetRecurrenceTypeOfEnd(ValidationContext validationContext)
        {
            var containerType = validationContext.ObjectInstance.GetType();
            var field = containerType.GetProperty(TypeOfEnd);
            return (RecurrenceTypeOfEnd?)field?.GetValue(validationContext.ObjectInstance, null);
        }
    }
}
