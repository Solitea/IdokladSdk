using IdokladSdk.Clients.Readonly;
using IdokladSdk.Models.ReadOnly.MeasureCode;
using IdokladSdk.Requests.Core;
using IdokladSdk.Requests.Core.Modifiers.Sort.BasicSorts;
using IdokladSdk.Requests.ReadOnly.MeasureCode.Filter;

namespace IdokladSdk.Requests.ReadOnly.MeasureCode
{
    /// <summary>
    /// Paged list of units of measure. The default API order is rank descending, then code.
    /// </summary>
    public class MeasureCodeList : BaseList<MeasureCodeList, MeasureCodeClient, MeasureCodeListGetModel, MeasureCodeFilter, IdSort>
    {
        /// <summary>Initializes a new instance of the <see cref="MeasureCodeList"/> class.</summary>
        /// <param name="client">Measure code client.</param>
        public MeasureCodeList(MeasureCodeClient client)
            : base(client)
        {
        }
    }
}
