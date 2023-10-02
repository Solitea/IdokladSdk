using IdokladSdk.Models.Common;
using IdokladSdk.Validation.Attributes;

namespace IdokladSdk.UnitTests.Tests.Validation.Detailed.Model
{
    public class ModelWithRangeNullableAttribute
    {
        [RangeNullable(0.0, 99.99)]
        public NullableProperty<decimal> RangeValue { get; set; }
    }
}
