using IdokladSdk.Validation.Attributes;

namespace IdokladSdk.UnitTests.Tests.Validation.Detailed.Model
{
    public class ModelWithHasNoIdentificationNumber
    {
        public bool HasNoIdentificationNumber { get; set; }

        [IdentificationNumber(nameof(HasNoIdentificationNumber))]
        public string IdentificationNumber { get; set; }
    }
}
