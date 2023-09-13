using IdokladSdk.Enums;
using IdokladSdk.Validation.Attributes;

namespace IdokladSdk.UnitTests.Tests.Validation.Detailed.Model.RecurringInvoice
{
    public class ModelWithCopyCountEndOnRecurringInvoiceAttribute
    {
        [CopyCountEndOnRecurringInvoice(nameof(TypeOfEnd))]
        public int? CopyCountEnd { get; set; }

        public RecurrenceTypeOfEnd TypeOfEnd { get; set; }
    }
}
