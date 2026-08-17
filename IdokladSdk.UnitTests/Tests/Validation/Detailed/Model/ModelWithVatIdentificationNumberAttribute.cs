using IdokladSdk.Validation.Attributes;

namespace IdokladSdk.UnitTests.Tests.Validation.Detailed.Model
{
    public class ModelWithVatIdentificationNumberAttribute
    {
        [VatIdentificationNumber]
        public string VatIdentificationNumber { get; set; }
    }
}
