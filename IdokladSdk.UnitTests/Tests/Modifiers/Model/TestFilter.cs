using System;
using IdokladSdk.Requests.Core.Modifiers.Filters.Common;

namespace IdokladSdk.UnitTests.Tests.Modifiers.Model
{
    public class TestFilter
    {
        public FilterItem<int> Id { get; set; } = new FilterItem<int>("Id");

        public CompareFilterItem<DateTime> Date { get; set; } = new CompareFilterItem<DateTime>("Date");

        public ContainFilterItem<string> Name { get; set; } = new ContainFilterItem<string>("Name");
    }
}