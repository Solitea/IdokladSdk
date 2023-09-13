using IdokladSdk.Enums;
using IdokladSdk.Models.Common;
using IdokladSdk.Validation.Attributes;

namespace IdokladSdk.UnitTests.Tests.Validation.Detailed.Model.RecurringInvoice
{
    public class ModelWithCopyCountEndOnRecurringInvoiceNullableAttribute
    {
        [CopyCountEndOnRecurringInvoice(nameof(TypeOfEnd))]
        public NullableProperty<int> CopyCountEnd { get; set; }

        public RecurrenceTypeOfEnd TypeOfEnd { get; set; }
    }
}
