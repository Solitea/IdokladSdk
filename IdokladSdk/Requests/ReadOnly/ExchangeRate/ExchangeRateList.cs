using IdokladSdk.Clients.Readonly;
using IdokladSdk.Models.ReadOnly.ExchangeRate;
using IdokladSdk.Requests.Core;
using IdokladSdk.Requests.Core.Modifiers.Sort.BasicSorts;
using IdokladSdk.Requests.ReadOnly.ExchangeRate.Filter;

namespace IdokladSdk.Requests.ReadOnly.ExchangeRate
{
    /// <summary>
    /// List of exchange rates.
    /// </summary>
    public class ExchangeRateList : BaseList<ExchangeRateList, ExchangeRateClient, ExchangeRateListGetModel, ExchangeRateFilter, IdSort>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ExchangeRateList"/> class.
        /// </summary>
        /// <param name="client">Exchange rate client.</param>
        public ExchangeRateList(ExchangeRateClient client)
            : base(client)
        {
        }
    }
}
