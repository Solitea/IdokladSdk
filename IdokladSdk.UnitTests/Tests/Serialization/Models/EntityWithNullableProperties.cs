using System;
using IdokladSdk.Models.Common;

namespace IdokladSdk.UnitTests.Tests.Serialization.Models
{
    /// <summary>
    /// EntityWithNullableProperties.
    /// </summary>
    public class EntityWithNullableProperties
    {
        public NullableProperty<DateTime> Date { get; set; }

        public NullableProperty<decimal> Decimal { get; set; }
    }
}
