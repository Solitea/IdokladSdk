using System.ComponentModel.DataAnnotations;

namespace IdokladSdk.UnitTests.Tests.Validation.Detailed.Model;

public class ModelWithRequiredAttribute
{
    [Required]
    public string Name { get; set; }
}
