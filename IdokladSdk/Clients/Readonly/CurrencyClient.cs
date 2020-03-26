using IdokladSdk.Clients.Interfaces;
using IdokladSdk.Requests.ReadOnly.Currency;

namespace IdokladSdk.Clients.Readonly
{
    /// <summary>
    /// Client for communication with Currencies endpoints.
    /// </summary>
    public class CurrencyClient :
        BaseClient,
        IEntityDetail<CurrencyDetail>,
        IEntityList<CurrencyList>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CurrencyClient"/> class.
        /// </summary>
        /// <param name="apiContext">API context.</param>
        public CurrencyClient(ApiContext apiContext)
            : base(apiContext)
        {
        }

        /// <inheritdoc/>
        public override string ResourceUrl { get; } = "/Currencies";

        /// <inheritdoc/>
        public CurrencyDetail Detail(int id)
        {
            return new CurrencyDetail(id, this);
        }

        /// <inheritdoc/>
        public CurrencyList List()
        {
            return new CurrencyList(this);
        }
    }
}
