using IdokladSdk.Clients.Readonly;
using IdokladSdk.Models.ReadOnly.ConstantSymbol;
using IdokladSdk.Requests.Core;
using IdokladSdk.Requests.Core.Modifiers.Sort.BasicSorts;
using IdokladSdk.Requests.ReadOnly.ConstantSymbol.Filter;

namespace IdokladSdk.Requests.ReadOnly.ConstantSymbol
{
    /// <summary>
    /// List of constant symbols.
    /// </summary>
    public class ConstantSymbolList : BaseList<ConstantSymbolList, ConstantSymbolClient, ConstantSymbolListGetModel, ConstantSymbolFilter, IdSort>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ConstantSymbolList"/> class.
        /// </summary>
        /// <param name="client">Constant symbol client.</param>
        public ConstantSymbolList(ConstantSymbolClient client)
            : base(client)
        {
        }
    }
}
