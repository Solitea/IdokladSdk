using IdokladSdk.Clients.Interfaces;
using IdokladSdk.Requests.ReadOnly.VatCodes;

namespace IdokladSdk.Clients.Readonly
{
    /// <summary>
    /// Client for communication with VatCodes endpoints.
    /// </summary>
    public class VatCodeClient :
        BaseClient,
        IEntityDetail<VatCodeDetail>,
        IEntityList<VatCodeList>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="VatCodeClient"/> class.
        /// </summary>
        /// <param name="apiContext">API context.</param>
        public VatCodeClient(ApiContext apiContext)
            : base(apiContext)
        {
        }

        /// <inheritdoc/>
        public override string ResourceUrl { get; } = "/VatCodes";

        /// <inheritdoc/>
        public VatCodeDetail Detail(int id)
        {
            return new VatCodeDetail(id, this);
        }

        /// <inheritdoc/>
        public VatCodeList List()
        {
            return new VatCodeList(this);
        }
    }
}
