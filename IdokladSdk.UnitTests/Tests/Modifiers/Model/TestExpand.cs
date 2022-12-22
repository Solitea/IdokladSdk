using IdokladSdk.Requests.Core.Modifiers.Expand.Common;

namespace IdokladSdk.UnitTests.Tests.Modifiers.Model
{
    public class TestExpand : ExpandableEntity
    {
        public TestExpandModel1 TestExpandModel1 { get; set; }

        public TestExpandModel2 TestExpandModel2 { get; set; }
    }
}