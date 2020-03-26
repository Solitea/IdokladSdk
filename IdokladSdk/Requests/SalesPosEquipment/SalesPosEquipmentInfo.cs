using System.Collections.Generic;
using IdokladSdk.Clients;
using IdokladSdk.Response;

namespace IdokladSdk.Requests.SalesPosEquipment
{
    /// <summary>
    /// Detail of authorized sales pos equipment.
    /// </summary>
    public partial class SalesPosEquipmentInfo : SalesPosEquipmentDetail
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SalesPosEquipmentInfo"/> class.
        /// </summary>
        /// <param name="client">Sales Pos Equipment client.</param>
        public SalesPosEquipmentInfo(SalesPosEquipmentClient client)
            : base(client)
        {
        }

        /// <inheritdoc/>
        protected override ApiResult<TResult> GetCore<TResult>(Dictionary<string, string> queryParams)
        {
            return Client.Get<TResult>($"{Client.ResourceUrl}/Info", queryParams);
        }
    }
}
