using System;
using IdokladSdk.Enums;
using IdokladSdk.Models.Common;
using IdokladSdk.Validation.Attributes;

namespace IdokladSdk.UnitTests.Tests.Validation.Detailed.Model.RecurringInvoice
{
    public class ModelWithDateOfEndOnRecurringInvoiceNullableAttribute
    {
        [DateOfEndOnRecurringInvoice(nameof(TypeOfEnd))]
        public NullableProperty<DateTime> DateOfEnd { get; set; }

        public RecurrenceTypeOfEnd TypeOfEnd { get; set; }
    }
}
