using IdokladSdk.Models.Common;
using IdokladSdk.Validation.Attributes;

namespace IdokladSdk.UnitTests.Tests.Validation.Detailed.Model
{
    public class ModelWithNullableRangeAttribute
    {
        [NullableRange(0, 100)]
        public NullableProperty<decimal> Amount { get; set; }
    }
}