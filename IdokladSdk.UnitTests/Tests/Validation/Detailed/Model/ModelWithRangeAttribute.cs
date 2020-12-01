using System.ComponentModel.DataAnnotations;

namespace IdokladSdk.UnitTests.Tests.Validation.Detailed.Model
{
    public class ModelWithRangeAttribute
    {
        [Range(0, 100)]
        public double Discount { get; set; }
    }
}
