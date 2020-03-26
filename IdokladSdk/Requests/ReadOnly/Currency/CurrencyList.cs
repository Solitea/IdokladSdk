using IdokladSdk.Clients.Readonly;
using IdokladSdk.Models.ReadOnly.Currency;
using IdokladSdk.Requests.Core;
using IdokladSdk.Requests.Core.Modifiers.Sort.BasicSorts;
using IdokladSdk.Requests.ReadOnly.Currency.Filter;

namespace IdokladSdk.Requests.ReadOnly.Currency
{
    /// <summary>
    /// List of currencies.
    /// </summary>
    public class CurrencyList : BaseList<CurrencyList, CurrencyClient, CurrencyListGetModel, CurrencyFilter, IdSort>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CurrencyList"/> class.
        /// </summary>
        /// <param name="client">Currency client.</param>
        public CurrencyList(CurrencyClient client)
            : base(client)
        {
        }
    }
}
