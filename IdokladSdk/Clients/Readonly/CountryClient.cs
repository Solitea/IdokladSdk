using IdokladSdk.Clients.Interfaces;
using IdokladSdk.Requests.ReadOnly.Country;

namespace IdokladSdk.Clients.Readonly
{
    /// <summary>
    /// Client for communication with Countries endpoints.
    /// </summary>
    public class CountryClient :
        BaseClient,
        IEntityDetail<CountryDetail>,
        IEntityList<CountryList>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CountryClient"/> class.
        /// </summary>
        /// <param name="apiContext">API context.</param>
        public CountryClient(ApiContext apiContext)
            : base(apiContext)
        {
        }

        /// <inheritdoc/>
        public override string ResourceUrl { get; } = "/Countries";

        /// <inheritdoc/>
        public CountryDetail Detail(int id)
        {
            return new CountryDetail(id, this);
        }

        /// <inheritdoc/>
        public CountryList List()
        {
            return new CountryList(this);
        }
    }
}
