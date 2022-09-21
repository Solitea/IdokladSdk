using IdokladSdk.Validation.Attributes;

namespace IdokladSdk.UnitTests.Tests.Validation.Detailed.Model
{
    public class PostModelWithIdentificationNumberAttribute
    {
        public bool HasNoIdentificationNumber { get; set; }

        [IdentificationNumberPost(nameof(HasNoIdentificationNumber))]
        public string IdentificationNumber { get; set; }
    }
}
