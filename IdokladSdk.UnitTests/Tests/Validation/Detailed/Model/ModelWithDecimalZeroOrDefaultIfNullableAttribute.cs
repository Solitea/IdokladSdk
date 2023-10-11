using IdokladSdk.Enums;
using IdokladSdk.Models.Common;
using IdokladSdk.Validation.Attributes;

namespace IdokladSdk.UnitTests.Tests.Validation.Detailed.Model
{
    public class ModelWithDecimalZeroOrDefaultIfNullableAttribute
    {
        public NullableProperty<IssuedDocumentTemplateType> DependentValue { get; set; }

        [DecimalZeroOrDefaultIf(nameof(DependentValue), IssuedDocumentTemplateType.SalesOrder)]
        public NullableProperty<decimal> PropertyValue { get; set; }
    }
}
