using IdokladSdk.Enums;
using IdokladSdk.Models.BankStatement.Post;

namespace IdokladSdk.Models.BankStatement.Get
{
    /// <summary>
    /// Bank statement default get model.
    /// </summary>
    public class BankStatementDefaultGetModel : BankStatementPostModel
    {
        /// <summary>
        /// Gets or sets VAT regime.
        /// </summary>
        public VatRegime VatRegime { get; set; }
    }
}
