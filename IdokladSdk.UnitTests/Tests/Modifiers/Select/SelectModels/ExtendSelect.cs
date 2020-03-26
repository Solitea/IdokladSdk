using System.Collections.Generic;

namespace IdokladSdk.UnitTests.Tests.Modifiers.Select.SelectModels
{
    /// <summary>
    /// ExtendSelect.
    /// </summary>
    public class ExtendSelect : BaseSelect
    {
        public string Name { get; set; }

        public SelectModel Model { get; set; }

        public List<SelectModel> Items { get; set; }
    }
}
