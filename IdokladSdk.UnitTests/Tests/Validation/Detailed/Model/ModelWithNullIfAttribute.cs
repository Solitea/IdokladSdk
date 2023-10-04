using IdokladSdk.Enums;
using IdokladSdk.Validation.Attributes;

namespace IdokladSdk.UnitTests.Tests.Validation.Detailed.Model
{
    public class ModelWithNullIfAttribute
    {
        public IssuedDocumentTemplateType DependentValue { get; set; }

        [NullIf(nameof(DependentValue), IssuedDocumentTemplateType.SalesOrder)]
        public int? PropertyValue { get; set; }
    }
}
