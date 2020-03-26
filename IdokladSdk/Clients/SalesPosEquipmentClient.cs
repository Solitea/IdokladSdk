using IdokladSdk.Clients.Interfaces;
using IdokladSdk.Requests.SalesPosEquipment;

namespace IdokladSdk.Clients
{
    /// <summary>
    /// Client for communication with POS equipment endpoints.
    /// </summary>
    public class SalesPosEquipmentClient :
        BaseClient,
        IEntityDetail<SalesPosEquipmentDetail>,
        IEntityList<SalesPosEquipmentList>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SalesPosEquipmentClient"/> class.
        /// </summary>
        /// <param name="apiContext">API context.</param>
        public SalesPosEquipmentClient(ApiContext apiContext)
            : base(apiContext)
        {
        }

        /// <inheritdoc/>
        public override string ResourceUrl { get; } = "/SalesPosEquipments";

        /// <inheritdoc/>
        public SalesPosEquipmentDetail Detail(int id)
        {
            return new SalesPosEquipmentDetail(id, this);
        }

        /// <summary>
        /// Detail of authorized POS equipment endpoint.
        /// </summary>
        /// <returns><see cref="SalesPosEquipmentInfo"/> instance.</returns>
        public SalesPosEquipmentInfo Info()
        {
            return new SalesPosEquipmentInfo(this);
        }

        /// <inheritdoc/>
        public SalesPosEquipmentList List()
        {
            return new SalesPosEquipmentList(this);
        }
    }
}
