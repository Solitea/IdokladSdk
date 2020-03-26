using IdokladSdk.Clients.Interfaces;
using IdokladSdk.Requests.ReadOnly.ConstantSymbol;

namespace IdokladSdk.Clients.Readonly
{
    /// <summary>
    /// Client for communication with ConstantSymbols endpoints.
    /// </summary>
    public class ConstantSymbolClient :
        BaseClient,
        IEntityDetail<ConstantSymbolDetail>,
        IEntityList<ConstantSymbolList>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ConstantSymbolClient"/> class.
        /// </summary>
        /// <param name="apiContext">API context.</param>
        public ConstantSymbolClient(ApiContext apiContext)
            : base(apiContext)
        {
        }

        /// <inheritdoc/>
        public override string ResourceUrl { get; } = "/ConstantSymbols";

        /// <inheritdoc/>
        public ConstantSymbolDetail Detail(int id)
        {
            return new ConstantSymbolDetail(id, this);
        }

        /// <inheritdoc/>
        public ConstantSymbolList List()
        {
            return new ConstantSymbolList(this);
        }
    }
}
