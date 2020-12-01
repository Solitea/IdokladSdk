using System;
using IdokladSdk.Validation.Attributes;

namespace IdokladSdk.UnitTests.Tests.Validation.Detailed.Model
{
    public class ModelWithRequiredIfHasValueAttribute
    {
        [RequiredIfHasValue(nameof(DateInitialState))]
        public decimal? InitialState { get; set; }

        [RequiredIfHasValue(nameof(InitialState))]
        public DateTime? DateInitialState { get; set; }
    }
}
