using System.Collections.Generic;
using IdokladSdk.Models.BankAccount;
using IdokladSdk.Models.BankStatement.Get;
using IdokladSdk.Models.Common;
using IdokladSdk.Models.Contact;
using IdokladSdk.Models.NumericSequence;
using IdokladSdk.Models.ReadOnly.ConstantSymbol;
using IdokladSdk.Models.ReadOnly.Currency;

namespace IdokladSdk.Models.BankStatement
{
    /// <summary>
    /// BankStatementGetModel.
    /// </summary>
    public class BankStatementGetModel : BankStatementListGetModel
    {
        /// <summary>
        /// Gets or sets bank account.
        /// </summary>
        public BankAccountGetModel BankAccount { get; set; }

        /// <summary>
        /// Gets or sets bank statement items.
        /// </summary>
        public new List<BankStatementItemGetModel> Items { get; set; }

        /// <summary>
        /// Gets or sets numeric sequence.
        /// </summary>
        public NumericSequenceGetModel NumericSequence { get; set; }

        /// <summary>
        /// Gets or sets constant symbol.
        /// </summary>
        public ConstantSymbolGetModel ConstantSymbol { get; set; }

        /// <summary>
        /// Gets or sets currency.
        /// </summary>
        public CurrencyGetModel Currency { get; set; }

        /// <summary>
        /// Gets or sets Partner.
        /// </summary>
        public ContactGetModel Partner { get; set; }

        /// <summary>
        /// Gets or sets tags.
        /// </summary>
        public new List<TagDocumentGetModel> Tags { get; set; }
    }
}
