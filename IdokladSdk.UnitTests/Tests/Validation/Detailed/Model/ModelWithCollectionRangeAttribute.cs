using System.Collections.Generic;
using IdokladSdk.Validation.Attributes;

namespace IdokladSdk.UnitTests.Tests.Validation.Detailed.Model
{
    public class ModelWithCollectionRangeAttribute
    {
        [CollectionRange(1, 2, false)]
        public List<int> EntityIds { get; set; }
    }
}