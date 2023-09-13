using IdokladSdk.Enums;
using IdokladSdk.Validation.Attributes;

namespace IdokladSdk.UnitTests.Tests.Validation.Detailed.Model.RecurringInvoice
{
    public class ModelWithIssueLastDayOfMonthOnRecurringInvoiceAttribute
    {
        [IssueLastDayOfMonthOnRecurringInvoice(nameof(RecurrenceType), nameof(RecurrenceCount))]
        public bool IssueLastDayOfMonth { get; set; }

        public RecurrenceType RecurrenceType { get; set; }

        public int RecurrenceCount { get; set; }
    }
}
