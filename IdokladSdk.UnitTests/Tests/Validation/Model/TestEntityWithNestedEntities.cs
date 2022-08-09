using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace IdokladSdk.UnitTests.Tests.Validation.Model
{
    public class TestEntityWithNestedEntities
    {
        [Required]
        public TestEntity Entity { get; set; }

        [Required]
        public IEnumerable<TestEntity> Entities { get; set; }
    }
}
