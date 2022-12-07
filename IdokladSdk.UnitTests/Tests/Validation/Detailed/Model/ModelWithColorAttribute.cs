using IdokladSdk.Validation.Attributes;

namespace IdokladSdk.UnitTests.Tests.Validation.Detailed.Model;

public class ModelWithColorAttribute
{
    [Color]
    public string Color { get; set; }
}
