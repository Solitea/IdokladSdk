using System;
using IdokladSdk.Validation.Attributes;

namespace IdokladSdk.UnitTests.Tests.Validation.Detailed.Model
{
    public class ModelWithDateGreaterOrEqualThanAnotherDateAttributeDefaultDate
    {
        [DateGreaterThanOrEqualThanAnotherDate(nameof(DateOfIssue), true)]
        public DateTime DateOfExpiration { get; set; }

        public DateTime DateOfIssue { get; set; }
    }
}
