using IdokladSdk.Requests.Core.Modifiers.Expand.Common;

namespace IdokladSdk.UnitTests.Tests.Modifiers.Model;

public class TestExpandModel1 : ExpandableEntity
{
    public TestExpandModel2 TestExpandModel2 { get; set; }

    public TestExpandModel3 TestExpandModel3 { get; set; }
}
