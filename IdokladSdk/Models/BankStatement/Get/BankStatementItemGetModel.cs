using IdokladSdk.Models.ReadOnly.VatCode;

namespace IdokladSdk.Models.BankStatement.Get
{
    /// <summary>
    /// BankStatementItemGetModel.
    /// </summary>
    public class BankStatementItemGetModel : BankStatementItemListGetModel
    {
        /// <summary>
        /// Gets or sets Vat Code.
        /// </summary>
        public VatCodeGetModel VatCode { get; set; }
    }
}
