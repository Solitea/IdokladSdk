using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using IdokladSdk.Models.Base;

namespace IdokladSdk.UnitTests.Tests.Validation.Model
{
    public class TestEntityWithNestedEntities : ValidatableModel
    {
        [Required]
        public TestEntity Entity { get; set; }

        [Required]
        public IEnumerable<TestEntity> Entities { get; set; }
    }
}
