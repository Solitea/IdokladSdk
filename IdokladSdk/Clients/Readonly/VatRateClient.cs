using IdokladSdk.Clients.Interfaces;
using IdokladSdk.Requests.ReadOnly.VatRate;

namespace IdokladSdk.Clients.Readonly
{
    /// <summary>
    /// Client for communication with VatRates endpoints.
    /// </summary>
    public class VatRateClient :
        BaseClient,
        IEntityDetail<VatRateDetail>,
        IEntityList<VatRateList>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="VatRateClient"/> class.
        /// </summary>
        /// <param name="apiContext">API context.</param>
        public VatRateClient(ApiContext apiContext)
            : base(apiContext)
        {
        }

        /// <inheritdoc/>
        public override string ResourceUrl { get; } = "/VatRates";

        /// <inheritdoc/>
        public VatRateDetail Detail(int id)
        {
            return new VatRateDetail(id, this);
        }

        /// <inheritdoc/>
        public VatRateList List()
        {
            return new VatRateList(this);
        }
    }
}
