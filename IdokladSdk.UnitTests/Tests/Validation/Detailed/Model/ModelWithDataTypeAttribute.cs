using System.ComponentModel.DataAnnotations;

namespace IdokladSdk.UnitTests.Tests.Validation.Detailed.Model
{
    public class ModelWithDataTypeAttribute
    {
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
    }
}
