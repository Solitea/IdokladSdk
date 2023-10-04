using IdokladSdk.Enums;
using IdokladSdk.Validation.Attributes;

namespace IdokladSdk.UnitTests.Tests.Validation.Detailed.Model
{
    public class ModelWithCannotEqualIfAttribute
    {
        public IssuedDocumentTemplateType DependentValue { get; set; }

        [CannotEqualIf(0.0, nameof(DependentValue), IssuedDocumentTemplateType.SalesOrder)]
        public decimal PropertyValue { get; set; }
    }
}
