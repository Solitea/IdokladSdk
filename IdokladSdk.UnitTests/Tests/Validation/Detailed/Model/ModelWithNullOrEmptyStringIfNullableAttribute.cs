using IdokladSdk.Enums;
using IdokladSdk.Models.Common;
using IdokladSdk.Validation.Attributes;

namespace IdokladSdk.UnitTests.Tests.Validation.Detailed.Model
{
    public class ModelWithNullOrEmptyStringIfNullableAttribute
    {
        [NullOrEmptyStringIf(nameof(DependentValue), IssuedDocumentTemplateType.SalesOrder)]
        public string PropertyValue { get; set; }

        public NullableProperty<IssuedDocumentTemplateType> DependentValue { get; set; }
    }
}
