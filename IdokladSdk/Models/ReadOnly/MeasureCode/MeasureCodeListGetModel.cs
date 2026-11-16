using System;

namespace IdokladSdk.Models.ReadOnly.MeasureCode
{
    /// <summary>
    /// A supported unit of measure and its standardized code.
    /// </summary>
    public class MeasureCodeListGetModel : IEntityId
    {
        /// <summary>Gets or sets the unit ID.</summary>
        public int Id { get; set; }

        /// <summary>Gets or sets the standardized unit code.</summary>
        public string Code { get; set; }

        /// <summary>Gets or sets the unit name.</summary>
        public string Name { get; set; }

        /// <summary>Gets or sets the unit rank used by the default API ordering.</summary>
        public int Rank { get; set; }

        /// <summary>Gets or sets the date the unit was last changed.</summary>
        public DateTime DateLastChange { get; set; }
    }
}
