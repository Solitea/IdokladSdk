using IdokladSdk.Clients.Readonly;
using IdokladSdk.Models.ReadOnly.ConstantSymbol;
using IdokladSdk.Requests.Core;
using IdokladSdk.Requests.Core.Modifiers.Expand.Structure;

namespace IdokladSdk.Requests.ReadOnly.ConstantSymbol
{
    /// <summary>
    /// Detail of constant symbol.
    /// </summary>
    public class ConstantSymbolDetail : ExpandableDetail<ConstantSymbolDetail, ConstantSymbolClient, ConstantSymbolGetModel, ConstantSymbolExpand>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ConstantSymbolDetail"/> class.
        /// </summary>
        /// <param name="id">Constant symbol id.</param>
        /// <param name="client">Constant symbol client.</param>
        public ConstantSymbolDetail(int id, ConstantSymbolClient client)
            : base(id, client)
        {
        }
    }
}
