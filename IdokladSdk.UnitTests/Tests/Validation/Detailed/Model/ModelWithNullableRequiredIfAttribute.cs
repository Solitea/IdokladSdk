using System;
using IdokladSdk.Models.Common;
using IdokladSdk.Validation.Attributes;

namespace IdokladSdk.UnitTests.Tests.Validation.Detailed.Model
{
    public class ModelWithNullableRequiredIfAttribute
    {
        public NullableProperty<bool> DependentValue { get; set; }

        [RequiredIf(nameof(DependentValue), true)]
        public NullableProperty<DateTime> PropertyValue { get; set; }
    }
}
