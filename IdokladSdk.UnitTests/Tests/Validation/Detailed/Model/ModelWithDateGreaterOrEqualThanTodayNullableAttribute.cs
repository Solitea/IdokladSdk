using System;
using IdokladSdk.Models.Common;
using IdokladSdk.Validation.Attributes;

namespace IdokladSdk.UnitTests.Tests.Validation.Detailed.Model
{
    public class ModelWithDateGreaterOrEqualThanTodayNullableAttribute
    {
        [DateGreaterOrEqualThanToday]
        public NullableProperty<DateTime> Date { get; set; }
    }
}
