using System.ComponentModel.DataAnnotations;
using IdokladSdk.Enums;

namespace IdokladSdk.Validation.Attributes
{
    public class IssueLastDayOfMonthOnRecurringInvoiceAttribute : ValidationAttribute
    {
        public IssueLastDayOfMonthOnRecurringInvoiceAttribute(string typeOfEnd, string recurrenceCount)
        {
            TypeOfEnd = typeOfEnd;
            RecurrenceCount = recurrenceCount;
        }

        private string RecurrenceCount { get; }

        private string TypeOfEnd { get; }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var issueLastDayOfMonth = (bool)value;

            if (issueLastDayOfMonth)
            {
                var typeOfEnd = GetRecurrenceType(validationContext);
                if (typeOfEnd != RecurrenceType.Months)
                {
                    return new ValidationResult(
                        $"For the field {validationContext.MemberName} is valid only {nameof(RecurrenceType)}.{RecurrenceType.Months}",
                        new[] { validationContext.MemberName });
                }

                var recurrenceCount = GetRecurrenceCount(validationContext);
                if (recurrenceCount != 1)
                {
                    return new ValidationResult(
                        $"For the field {validationContext.MemberName} is valid only {nameof(RecurrenceCount)} equals 1",
                        new[] { validationContext.MemberName });
                }
            }

            return ValidationResult.Success;
        }

        private int? GetRecurrenceCount(ValidationContext validationContext)
        {
            var containerType = validationContext.ObjectInstance.GetType();
            var field = containerType.GetProperty(RecurrenceCount);
            return (int?)field?.GetValue(validationContext.ObjectInstance, null);
        }

        private RecurrenceType? GetRecurrenceType(ValidationContext validationContext)
        {
            var containerType = validationContext.ObjectInstance.GetType();
            var field = containerType.GetProperty(TypeOfEnd);
            return (RecurrenceType?)field?.GetValue(validationContext.ObjectInstance, null);
        }
    }
}
