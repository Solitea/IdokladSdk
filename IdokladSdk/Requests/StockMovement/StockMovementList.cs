using IdokladSdk.Clients;
using IdokladSdk.Models.StockMovement;
using IdokladSdk.Requests.Core;
using IdokladSdk.Requests.Core.Modifiers.Sort.BasicSorts;
using IdokladSdk.Requests.StockMovement.Filter;

namespace IdokladSdk.Requests.StockMovement
{
    /// <summary>
    /// StockMovementList.
    /// </summary>
    public class StockMovementList : BaseList<StockMovementList, StockMovementClient, StockMovementListGetModel, StockMovementFilter, IdSort>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="StockMovementList"/> class.
        /// </summary>
        /// <param name="client">Client.</param>
        public StockMovementList(StockMovementClient client)
            : base(client)
        {
        }
    }
}
