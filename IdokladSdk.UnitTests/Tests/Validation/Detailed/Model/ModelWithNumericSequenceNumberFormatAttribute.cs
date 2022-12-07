using IdokladSdk.Validation.Attributes;

namespace IdokladSdk.UnitTests.Tests.Validation.Detailed.Model;

public class ModelWithNumericSequenceNumberFormatAttribute
{
    public int? LastNumber { get; set; }

    [NumericSequenceNumberFormat(nameof(LastNumber))]
    public string NumberFormat { get; set; }
}
