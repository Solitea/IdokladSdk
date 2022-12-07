using IdokladSdk.Validation.Attributes;

namespace IdokladSdk.UnitTests.Tests.Validation.Detailed.Model;

public class PatchModelWithIdentificationNumberAttribute
{
    public bool? HasNoIdentificationNumber { get; set; }

    [IdentificationNumberPatch(nameof(HasNoIdentificationNumber))]
    public string IdentificationNumber { get; set; }
}
