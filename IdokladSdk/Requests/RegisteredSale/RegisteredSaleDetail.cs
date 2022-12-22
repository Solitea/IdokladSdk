using IdokladSdk.Clients;
using IdokladSdk.Enums;
using IdokladSdk.Models.RegisteredSale;
using IdokladSdk.Requests.Core;
using IdokladSdk.Requests.Core.Modifiers.Expand.Structure;

namespace IdokladSdk.Requests.RegisteredSale
{
    /// <summary>
    /// Detail of registered sale.
    /// </summary>
    public partial class RegisteredSaleDetail : ExpandableDetail<RegisteredSaleDetail, RegisteredSaleClient, RegisteredSaleGetModel, RegisteredSaleExpand>
    {
        private readonly RegisteredSaleType _type;

        /// <summary>
        /// Initializes a new instance of the <see cref="RegisteredSaleDetail"/> class.
        /// </summary>
        /// <param name="type">Type of document.</param>
        /// <param name="id">Id of document.</param>
        /// <param name="client">Registered sale client.</param>
        public RegisteredSaleDetail(RegisteredSaleType type, int id, RegisteredSaleClient client)
            : base(id, client)
        {
            _type = type;
        }
    }
}
