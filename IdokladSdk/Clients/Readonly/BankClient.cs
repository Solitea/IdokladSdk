using IdokladSdk.Clients.Interfaces;
using IdokladSdk.Requests.ReadOnly.Bank;

namespace IdokladSdk.Clients.Readonly
{
    /// <summary>
    /// Client for communication with Banks endpoints.
    /// </summary>
    public class BankClient :
        BaseClient,
        IEntityDetail<BankDetail>,
        IEntityList<BankList>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BankClient"/> class.
        /// </summary>
        /// <param name="apiContext">API context.</param>
        public BankClient(ApiContext apiContext)
            : base(apiContext)
        {
        }

        /// <inheritdoc/>
        public override string ResourceUrl { get; } = "/Banks";

        /// <inheritdoc/>
        public BankDetail Detail(int id)
        {
            return new BankDetail(id, this);
        }

        /// <inheritdoc/>
        public BankList List()
        {
            return new BankList(this);
        }
    }
}
