using System;
using IdokladSdk.Models.Common;
using IdokladSdk.Validation.Attributes;

namespace IdokladSdk.UnitTests.Tests.Validation.Detailed.Model
{
    public class ModelWithNullablePropertyDateGreaterOrEqualThanAnotherNullableDateAttribute
    {
        public DateTime? DateOfIssue { get; set; }

        [DateGreaterThanOrEqualThanAnotherDate(nameof(DateOfIssue))]
        public NullableProperty<DateTime> DateOfVatClaim { get; set; }
    }
}
