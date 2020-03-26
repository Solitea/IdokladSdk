using IdokladSdk.Clients;
using IdokladSdk.Models.StockMovement;
using IdokladSdk.Requests.Core;
using IdokladSdk.Requests.Core.Modifiers.Expand.Structure;

namespace IdokladSdk.Requests.StockMovement
{
    /// <summary>
    /// StockMovementDetail.
    /// </summary>
    public class StockMovementDetail : ExpandableDetail<StockMovementDetail, StockMovementClient, StockMovementGetModel, StockMovementExpand>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="StockMovementDetail"/> class.
        /// </summary>
        /// <param name="id">Id.</param>
        /// <param name="client">Client.</param>
        public StockMovementDetail(int id, StockMovementClient client)
            : base(id, client)
        {
        }
    }
}
