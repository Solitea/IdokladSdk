using IdokladSdk.Validation.Attributes;

namespace IdokladSdk.UnitTests.Tests.Validation.Detailed.Model
{
    public class ModelWithEmailAttribute
    {
        [Email]
        public string Email { get; set; }
    }
}