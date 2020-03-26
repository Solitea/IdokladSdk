using System.Collections.Generic;
using IdokladSdk.Models.ReadOnly.Bank;
using IdokladSdk.Models.ReadOnly.ConstantSymbol;
using IdokladSdk.Models.ReadOnly.Country;
using IdokladSdk.Models.ReadOnly.Currency;
using IdokladSdk.Models.ReadOnly.PaymentOption;
using IdokladSdk.Models.ReadOnly.VatCode;
using IdokladSdk.Models.ReadOnly.VatRate;
using IdokladSdk.Models.ReadOnly.VatReverseChargeCode;

namespace IdokladSdk.Models.ReadOnly
{
    /// <summary>
    /// Content of all codebooks.
    /// </summary>
    public class CodeBooksGetModel
    {
        /// <summary>
        /// Gets or sets banks.
        /// </summary>
        public List<BankListGetModel> Banks { get; set; }

        /// <summary>
        /// Gets or sets constant symbols.
        /// </summary>
        public List<ConstantSymbolListGetModel> ConstantSymbols { get; set; }

        /// <summary>
        /// Gets or sets countries.
        /// </summary>
        public List<CountryListGetModel> Countries { get; set; }

        /// <summary>
        /// Gets or sets currencies.
        /// </summary>
        public List<CurrencyListGetModel> Currencies { get; set; }

        /// <summary>
        /// Gets or sets payment options.
        /// </summary>
        public List<PaymentOptionListGetModel> PaymentOptions { get; set; }

        /// <summary>
        /// Gets or sets VAT codes.
        /// </summary>
        public List<VatCodeListGetModel> VatCodes { get; set; }

        /// <summary>
        /// Gets or sets VAT rates.
        /// </summary>
        public List<VatRateListGetModel> VatRates { get; set; }

        /// <summary>
        /// Gets or sets VAT reverse charge codes.
        /// </summary>
        public List<VatReverseChargeCodeListGetModel> VatReverseChargeCodes { get; set; }
    }
}
