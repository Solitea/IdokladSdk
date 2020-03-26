using IdokladSdk.Clients.Readonly;
using IdokladSdk.Models.ReadOnly.ExchangeRate;
using IdokladSdk.Requests.Core;
using IdokladSdk.Requests.Core.Modifiers.Expand.Structure;

namespace IdokladSdk.Requests.ReadOnly.ExchangeRate
{
    /// <summary>
    /// Detail of exchange rate.
    /// </summary>
    public class ExchangeRateDetail : ExpandableDetail<ExchangeRateDetail, ExchangeRateClient, ExchangeRateGetModel, ExchangeRateExpand>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ExchangeRateDetail"/> class.
        /// </summary>
        /// <param name="id">Exchange rate id.</param>
        /// <param name="client">Exchange rate client.</param>
        public ExchangeRateDetail(int id, ExchangeRateClient client)
            : base(id, client)
        {
        }
    }
}
