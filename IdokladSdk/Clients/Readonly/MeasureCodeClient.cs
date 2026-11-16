using IdokladSdk.Clients.Interfaces;
using IdokladSdk.Requests.ReadOnly.MeasureCode;

namespace IdokladSdk.Clients.Readonly
{
    /// <summary>
    /// Client for the units of measure codebook.
    /// </summary>
    public class MeasureCodeClient : BaseClient, IEntityDetail<MeasureCodeDetail>, IEntityList<MeasureCodeList>
    {
        /// <summary>Initializes a new instance of the <see cref="MeasureCodeClient"/> class.</summary>
        /// <param name="apiContext">API context.</param>
        public MeasureCodeClient(ApiContext apiContext)
            : base(apiContext)
        {
        }

        /// <inheritdoc/>
        public override string ResourceUrl { get; } = "/MeasureCodes";

        /// <inheritdoc/>
        public MeasureCodeDetail Detail(int id)
        {
            return new MeasureCodeDetail(id, this);
        }

        /// <inheritdoc/>
        public MeasureCodeList List()
        {
            return new MeasureCodeList(this);
        }
    }
}
