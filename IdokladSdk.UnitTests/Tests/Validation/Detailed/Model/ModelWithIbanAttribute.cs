using IdokladSdk.Validation.Attributes;

namespace IdokladSdk.UnitTests.Tests.Validation.Detailed.Model;

public class ModelWithIbanAttribute
{
    [Iban]
    public string Iban { get; set; }
}
