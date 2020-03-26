using IdokladSdk.Clients.Interfaces;
using IdokladSdk.Requests.ReadOnly.VatReverseChargeCodes;

namespace IdokladSdk.Clients.Readonly
{
    /// <summary>
    /// Client for communication with VatReverseChargeCodes endpoints.
    /// </summary>
    public class VatReverseChargeCodeClient :
        BaseClient,
        IEntityDetail<VatReverseChargeCodeDetail>,
        IEntityList<VatReverseChargeCodeList>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="VatReverseChargeCodeClient"/> class.
        /// </summary>
        /// <param name="apiContext">API context.</param>
        public VatReverseChargeCodeClient(ApiContext apiContext)
            : base(apiContext)
        {
        }

        /// <inheritdoc/>
        public override string ResourceUrl { get; } = "/VatReverseChargeCodes";

        /// <inheritdoc/>
        public VatReverseChargeCodeDetail Detail(int id)
        {
            return new VatReverseChargeCodeDetail(id, this);
        }

        /// <inheritdoc/>
        public VatReverseChargeCodeList List()
        {
            return new VatReverseChargeCodeList(this);
        }
    }
}
