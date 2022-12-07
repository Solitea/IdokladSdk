using System;
using IdokladSdk.Validation.Attributes;

namespace IdokladSdk.UnitTests.Tests.Validation.Detailed.Model;

public class ModelWithDateGreaterOrEqualThanAnotherDateAttribute
{
    [DateGreaterThanOrEqualThanAnotherDate(nameof(DateOfIssue))]
    public DateTime DateOfExpiration { get; set; }

    public DateTime DateOfIssue { get; set; }
}
