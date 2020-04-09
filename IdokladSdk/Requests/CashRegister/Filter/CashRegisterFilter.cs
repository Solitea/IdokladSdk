using IdokladSdk.Models.CashRegister;
using IdokladSdk.Requests.Core.Modifiers.Filters;
using IdokladSdk.Requests.Core.Modifiers.Filters.Common;

namespace IdokladSdk.Requests.CashRegister.Filter
{
    /// <summary>
    /// Filterable properties of cash register.
    /// </summary>
    public class CashRegisterFilter : IdFilter
    {
        /// <inheritdoc cref="CashRegisterListGetModel.CurrencyId"/>
        public FilterItem<int> CurrencyId { get; set; } = new FilterItem<int>(nameof(CashRegisterListGetModel.CurrencyId));
    }
}
