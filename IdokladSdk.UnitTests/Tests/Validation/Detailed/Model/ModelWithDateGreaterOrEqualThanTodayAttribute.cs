using System;
using IdokladSdk.Validation.Attributes;

namespace IdokladSdk.UnitTests.Tests.Validation.Detailed.Model
{
    public class ModelWithDateGreaterOrEqualThanTodayAttribute
    {
        [DateGreaterOrEqualThanToday]
        public DateTime Date { get; set; }
    }
}
