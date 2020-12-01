using System;
using IdokladSdk.Validation.Attributes;

namespace IdokladSdk.UnitTests.Tests.Validation.Detailed.Model
{
    public class ModelWithRequiredIfAttribute
    {
        public bool WasSent { get; set; }

        [RequiredIf(nameof(WasSent), true)]
        public DateTime? DateOfSent { get; set; }
    }
}
