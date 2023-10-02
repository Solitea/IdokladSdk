using IdokladSdk.Enums;
using IdokladSdk.Models.Common;
using IdokladSdk.Validation.Attributes;

namespace IdokladSdk.UnitTests.Tests.Validation.Detailed.Model
{
    public class ModelWithCannotEqualIfNullableAttribute
    {
        public NullableProperty<IssuedDocumentTemplateType> DependentValue { get; set; }

        [CannotEqualIf(0.0, nameof(DependentValue), IssuedDocumentTemplateType.SalesOrder)]
        public NullableProperty<decimal> PropertyValue { get; set; }
    }
}
