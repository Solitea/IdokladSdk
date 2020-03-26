using IdokladSdk.Clients.Readonly;
using IdokladSdk.Models.ReadOnly.Currency;
using IdokladSdk.Requests.Core;

namespace IdokladSdk.Requests.ReadOnly.Currency
{
    /// <summary>
    /// Detail of currency.
    /// </summary>
    public class CurrencyDetail : EntityDetail<CurrencyDetail, CurrencyClient, CurrencyGetModel>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CurrencyDetail"/> class.
        /// </summary>
        /// <param name="id">Currency id.</param>
        /// <param name="client">Currency client.</param>
        public CurrencyDetail(int id, CurrencyClient client)
            : base(id, client)
        {
        }
    }
}
