using System.Collections.Generic;
using IdokladSdk.Validation.Attributes;

namespace IdokladSdk.UnitTests.Tests.Validation.Detailed.Model;

public class ModelWithEmailCollectionAttribute
{
    [EmailCollection]
    public List<string> OtherRecipients { get; set; }
}
