using IdokladSdk.Clients.Interfaces;
using IdokladSdk.Requests.ReadOnly.ExchangeRate;

namespace IdokladSdk.Clients.Readonly
{
    /// <summary>
    /// Client for communication with ExchangeRates endpoints.
    /// </summary>
    public class ExchangeRateClient :
        BaseClient,
        IEntityDetail<ExchangeRateDetail>,
        IEntityList<ExchangeRateList>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ExchangeRateClient"/> class.
        /// </summary>
        /// <param name="apiContext">API context.</param>
        public ExchangeRateClient(ApiContext apiContext)
            : base(apiContext)
        {
        }

        /// <inheritdoc/>
        public override string ResourceUrl { get; } = "/ExchangeRates";

        /// <inheritdoc/>
        public ExchangeRateDetail Detail(int id)
        {
            return new ExchangeRateDetail(id, this);
        }

        /// <inheritdoc/>
        public ExchangeRateList List()
        {
            return new ExchangeRateList(this);
        }
    }
}
