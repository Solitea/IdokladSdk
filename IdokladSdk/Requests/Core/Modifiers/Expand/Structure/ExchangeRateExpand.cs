using IdokladSdk.Requests.Core.Modifiers.Expand.Common;

namespace IdokladSdk.Requests.Core.Modifiers.Expand.Structure
{
    /// <summary>
    /// ConstantSymbolExpand.
    /// </summary>
    public class ExchangeRateExpand : ExpandableEntity
    {
        /// <summary>
        /// Gets currency.
        /// </summary>
        public CurrencyExpand Currency { get; }
    }
}
