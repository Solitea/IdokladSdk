using IdokladSdk.Clients.Readonly;
using IdokladSdk.Models.ReadOnly.MeasureCode;
using IdokladSdk.Requests.Core;

namespace IdokladSdk.Requests.ReadOnly.MeasureCode
{
    /// <summary>
    /// Unit of measure detail request.
    /// </summary>
    public class MeasureCodeDetail : EntityDetail<MeasureCodeDetail, MeasureCodeClient, MeasureCodeGetModel>
    {
        /// <summary>Initializes a new instance of the <see cref="MeasureCodeDetail"/> class.</summary>
        /// <param name="id">Unit ID.</param>
        /// <param name="client">Measure code client.</param>
        public MeasureCodeDetail(int id, MeasureCodeClient client)
            : base(id, client)
        {
        }
    }
}
