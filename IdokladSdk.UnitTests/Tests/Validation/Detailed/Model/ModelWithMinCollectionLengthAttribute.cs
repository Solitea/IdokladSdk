using System.Collections.Generic;
using IdokladSdk.Validation.Attributes;

namespace IdokladSdk.UnitTests.Tests.Validation.Detailed.Model
{
    public class ModelWithMinCollectionLengthAttribute
    {
        [MinCollectionLength(1)]
        public List<int> RelatedEntityIds { get; set; }
    }
}
