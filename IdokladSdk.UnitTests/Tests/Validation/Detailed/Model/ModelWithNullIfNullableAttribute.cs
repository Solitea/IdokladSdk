using IdokladSdk.Enums;
using IdokladSdk.Models.Common;
using IdokladSdk.Validation.Attributes;

namespace IdokladSdk.UnitTests.Tests.Validation.Detailed.Model
{
    public class ModelWithNullIfNullableAttribute
    {
        [NullIf(nameof(DependentValue), IssuedDocumentTemplateType.SalesOrder)]
        public NullableProperty<int> PropertyValue { get; set; }

        public NullableProperty<IssuedDocumentTemplateType> DependentValue { get; set; }
    }
}
