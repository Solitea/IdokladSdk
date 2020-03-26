using IdokladSdk.Requests.Core.Modifiers.Sort.Common;

namespace IdokladSdk.UnitTests.Tests.Modifiers.Model
{
    public class TestSort
    {
        public SortItem Id { get; set; } = new SortItem("Id");

        public SortItem Name { get; set; } = new SortItem("Name");
    }
}
