using IdokladSdk.Validation.Attributes;

namespace IdokladSdk.UnitTests.Tests.Validation.Detailed.Model
{
    public class ModelWithDecimalGreaterThanZeroAttribute
    {
        [DecimalGreaterThanZero]
        public decimal Amount { get; set; }
    }
}