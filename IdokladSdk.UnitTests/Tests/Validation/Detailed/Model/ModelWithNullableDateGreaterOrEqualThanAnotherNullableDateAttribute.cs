using System;
using IdokladSdk.Validation.Attributes;

namespace IdokladSdk.UnitTests.Tests.Validation.Detailed.Model;

public class ModelWithNullableDateGreaterOrEqualThanAnotherNullableDateAttribute
{
    public DateTime? DateOfIssue { get; set; }

    [DateGreaterThanOrEqualThanAnotherDate(nameof(DateOfIssue))]
    public DateTime? DateOfVatClaim { get; set; }
}
