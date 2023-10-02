using IdokladSdk.Enums;
using IdokladSdk.Validation.Attributes;

namespace IdokladSdk.UnitTests.Tests.Validation.Detailed.Model
{
    public class ModelWithNullOrEmptyStringIfAttribute
    {
        [NullOrEmptyStringIf(nameof(DependentValue), IssuedDocumentTemplateType.SalesOrder)]
        public string PropertyValue { get; set; }

        public IssuedDocumentTemplateType DependentValue { get; set; }
    }
}
