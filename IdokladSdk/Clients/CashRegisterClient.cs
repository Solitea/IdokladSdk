using IdokladSdk.Clients.Interfaces;
using IdokladSdk.Requests.CashRegister;

namespace IdokladSdk.Clients
{
    /// <summary>
    /// Client for communication with cash register endpoints.
    /// </summary>
    public class CashRegisterClient : BaseClient,
        IEntityDetail<CashRegisterDetail>,
        IEntityList<CashRegisterList>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CashRegisterClient"/> class.
        /// </summary>
        /// <param name="apiContext">Context.</param>
        public CashRegisterClient(ApiContext apiContext)
            : base(apiContext)
        {
        }

        /// <inheritdoc />
        public override string ResourceUrl { get; } = "/CashRegisters";

        /// <inheritdoc/>
        public CashRegisterDetail Detail(int id)
        {
            return new CashRegisterDetail(id, this);
        }

        /// <inheritdoc/>
        public CashRegisterList List()
        {
            return new CashRegisterList(this);
        }
    }
}
