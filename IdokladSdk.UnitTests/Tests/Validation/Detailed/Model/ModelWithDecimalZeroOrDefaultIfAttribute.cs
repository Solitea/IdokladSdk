using IdokladSdk.Enums;
using IdokladSdk.Validation.Attributes;

namespace IdokladSdk.UnitTests.Tests.Validation.Detailed.Model
{
    public class ModelWithDecimalZeroOrDefaultIfAttribute
    {
        [DecimalZeroOrDefaultIf(nameof(DependentValue), IssuedDocumentTemplateType.SalesOrder)]
        public decimal PropertyValue { get; set; }

        public IssuedDocumentTemplateType DependentValue { get; set; }
    }
}
