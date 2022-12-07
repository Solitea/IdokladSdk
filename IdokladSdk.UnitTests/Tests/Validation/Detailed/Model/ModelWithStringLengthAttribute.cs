using System.ComponentModel.DataAnnotations;

namespace IdokladSdk.UnitTests.Tests.Validation.Detailed.Model;

public class ModelWithStringLengthAttribute
{
    [StringLength(20, MinimumLength = 10)]
    public string Name { get; set; }
}
