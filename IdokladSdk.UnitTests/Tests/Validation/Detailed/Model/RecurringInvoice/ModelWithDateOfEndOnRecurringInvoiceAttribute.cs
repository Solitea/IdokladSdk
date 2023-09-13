using System;
using IdokladSdk.Enums;
using IdokladSdk.Validation.Attributes;

namespace IdokladSdk.UnitTests.Tests.Validation.Detailed.Model.RecurringInvoice
{
    public class ModelWithDateOfEndOnRecurringInvoiceAttribute
    {
        [DateOfEndOnRecurringInvoice(nameof(TypeOfEnd))]
        public DateTime? DateOfEnd { get; set; }

        public RecurrenceTypeOfEnd TypeOfEnd { get; set; }
    }
}
