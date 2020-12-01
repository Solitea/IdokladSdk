using IdokladSdk.Validation.Attributes;

namespace IdokladSdk.UnitTests.Tests.Validation.Detailed.Model
{
    public class ModelWithNullableForeignKeyAttribute
    {
        [NullableForeignKey]
        public int SalesPosEuqipmentId { get; set; }
    }
}
