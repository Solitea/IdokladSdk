using IdokladSdk.Models.Common;

namespace IdokladSdk.UnitTests.Tests.Serialization.Models
{
    /// <summary>
    /// TestEntity.
    /// </summary>
    public class TestEntity
    {
        public int Id { get; set; }

        public NullableProperty<int> OtherEntityId { get; set; }
    }
}
