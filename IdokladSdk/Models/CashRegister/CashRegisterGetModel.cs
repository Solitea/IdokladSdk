using IdokladSdk.Models.ReadOnly.Currency;

namespace IdokladSdk.Models.CashRegister
{
    /// <summary>
    /// CashRegisterGetModel.
    /// </summary>
    public class CashRegisterGetModel : CashRegisterListGetModel
    {
        /// <summary>
        /// Gets or sets currency.
        /// </summary>
        public CurrencyGetModel Currency { get; set; }
    }
}
