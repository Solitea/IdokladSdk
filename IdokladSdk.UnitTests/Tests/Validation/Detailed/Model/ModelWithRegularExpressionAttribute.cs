using System.ComponentModel.DataAnnotations;

namespace IdokladSdk.UnitTests.Tests.Validation.Detailed.Model
{
    public class ModelWithRegularExpressionAttribute
    {
        [RegularExpression(@"^[0-9]{6,12}$")]
        public string DocumentNumber { get; set; }
    }
}
