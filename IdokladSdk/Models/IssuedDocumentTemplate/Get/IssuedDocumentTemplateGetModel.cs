using System.Collections.Generic;
using IdokladSdk.Models.BankAccount;
using IdokladSdk.Models.DeliveryAddress;
using IdokladSdk.Models.IssuedDocumentTemplate.List;
using IdokladSdk.Models.NumericSequence;
using IdokladSdk.Models.ReadOnly.ConstantSymbol;
using IdokladSdk.Models.ReadOnly.Currency;
using IdokladSdk.Models.ReadOnly.PaymentOption;
using IdokladSdk.Models.ReadOnly.VatReverseChargeCode;

namespace IdokladSdk.Models.IssuedDocumentTemplate.Get
{
    /// <summary>
    /// IssuedDocumentTemplateGetModel.
    /// </summary>
    public class IssuedDocumentTemplateGetModel : IssuedDocumentTemplateListGetModel
    {
        /// <summary>
        /// Gets or sets bank account.
        /// </summary>
        public BankAccountGetModel BankAccount { get; set; }

        /// <summary>
        /// Gets or sets constant symbol.
        /// </summary>
        public ConstantSymbolGetModel ConstantSymbol { get; set; }

        /// <summary>
        /// Gets or sets currency.
        /// </summary>
        public CurrencyGetModel Currency { get; set; }

        /// <summary>
        /// Gets or sets delivery address.
        /// </summary>
        public DeliveryAddressGetModel DeliveryAddress { get; set; }

        /// <summary>
        /// Gets or sets numeric sequence.
        /// </summary>
        public NumericSequenceGetModel NumericSequence { get; set; }

        /// <summary>
        /// Gets or sets payment option.
        /// </summary>
        public PaymentOptionGetModel PaymentOption { get; set; }

        /// <summary>
        /// Gets or sets VAT reverse charge code.
        /// </summary>
        public VatReverseChargeCodeGetModel VatReverseChargeCode { get; set; }

        /// <summary>
        /// Gets or sets invoice items.
        /// </summary>
        public new List<IssuedDocumentTemplateItemGetModel> Items { get; set; }
    }
}
