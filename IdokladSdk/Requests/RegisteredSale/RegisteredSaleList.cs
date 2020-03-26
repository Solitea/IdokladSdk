using IdokladSdk.Clients;
using IdokladSdk.Models.RegisteredSale;
using IdokladSdk.Requests.Core;
using IdokladSdk.Requests.RegisteredSale.Filter;
using IdokladSdk.Requests.RegisteredSale.Sort;

namespace IdokladSdk.Requests.RegisteredSale
{
    /// <summary>
    /// List of Registered sales.
    /// </summary>
    public class RegisteredSaleList : BaseList<RegisteredSaleList, RegisteredSaleClient, RegisteredSaleListGetModel, RegisteredSaleFilter, RegisteredSaleSort>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="RegisteredSaleList"/> class.
        /// </summary>
        /// <param name="client">Registered Sale client.</param>
        public RegisteredSaleList(RegisteredSaleClient client)
            : base(client)
        {
        }
    }
}
