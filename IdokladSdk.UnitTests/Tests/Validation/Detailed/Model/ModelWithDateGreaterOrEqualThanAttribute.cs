using System;
using IdokladSdk.Validation.Attributes;

namespace IdokladSdk.UnitTests.Tests.Validation.Detailed.Model;

public class ModelWithDateGreaterOrEqualThanAttribute
{
    [DateGreaterOrEqualThan(Constants.DefaultDateTimeString, false)]
    public DateTime DateOfIssue { get; set; }
}
