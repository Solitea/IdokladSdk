using IdokladSdk.Models.Common;
using IdokladSdk.Validation.Attributes;

namespace IdokladSdk.UnitTests.Tests.Validation.Detailed.Model
{
    public class ModelWithNullablePropertyAndNullableForeignKeyAttribute
    {
        [NullableForeignKey]
        public NullableProperty<int> BankId { get; set; }
    }
}