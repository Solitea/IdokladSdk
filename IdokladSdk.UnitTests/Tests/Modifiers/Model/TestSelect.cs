using System.Collections.Generic;

namespace IdokladSdk.UnitTests.Tests.Modifiers.Model;

public class TestSelect
{
    public int Id { get; set; }

    public string Name { get; set; }

    public TestSelectModel Model { get; set; }

    public List<TestSelectModel> Items { get; set; }
}
