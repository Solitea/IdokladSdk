using IdokladSdk.Validation.Attributes;

namespace IdokladSdk.UnitTests.Tests.Validation.Detailed.Model
{
    public class ModelWithNotEmptyStringAttribute
    {
        [NotEmptyString]
        public string Description { get; set; }
    }
}