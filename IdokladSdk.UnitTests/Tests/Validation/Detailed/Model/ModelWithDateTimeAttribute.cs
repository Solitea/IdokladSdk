using System;
using IdokladSdk.Models.Common;
using IdokladSdk.Validation.Attributes;

namespace IdokladSdk.UnitTests.Tests.Validation.Detailed.Model;

public class ModelWithDateTimeAttribute
{
    [DateTime]
    public DateTime DateOfIssue { get; set; }

    [DateTime]
    public NullableProperty<DateTime> DateOfPayment { get; set; }
}
