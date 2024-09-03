using System;
using System.Collections.Generic;
using IdokladSdk.Enums;
using IdokladSdk.Models.BankStatement.Get;
using IdokladSdk.Models.Common;
using IdokladSdk.Models.Common.PairedDocument;

namespace IdokladSdk.Models.BankStatement
{
    /// <summary>
    /// BankStatementListGetModel.
    /// </summary>
    public class BankStatementListGetModel : IEntityId
    {
        /// <summary>
        /// Gets or sets your bank account id.
        /// </summary>
        public int BankAccountId { get; set; }

        /// <summary>
        /// Gets or sets Constant symbol Id.
        /// </summary>
        public int? ConstantSymbolId { get; set; }

        /// <summary>
        /// Gets or sets Currency Id.
        /// </summary>
        public int CurrencyId { get; set; }

        /// <summary>
        /// Gets or sets current account balance.
        /// </summary>
        public decimal CurrentBalance { get; set; }

        /// <summary>
        /// Gets or sets Date of transaction.
        /// </summary>
        public DateTime DateOfTransaction { get; set; }

        /// <summary>
        /// Gets or sets Description.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets documentNumber.
        /// </summary>
        public string DocumentNumber { get; set; }

        /// <summary>
        /// Gets or sets document Serial Number.
        /// </summary>
        public int DocumentSerialNumber { get; set; }

        /// <summary>
        /// Gets or sets Exchange rate.
        /// </summary>
        public decimal ExchangeRate { get; set; }

        /// <summary>
        /// Gets or sets Exchange rate amount.
        /// </summary>
        public decimal ExchangeRateAmount { get; set; }

        /// <summary>
        /// Gets or sets Export to another accounting software indication. (It is recommended to use only one external accounting software beside iDoklad.)
        /// </summary>
        public ExportedState Exported { get; set; }

        /// <inheritdoc/>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether to Include subject to income tax.
        /// </summary>
        public bool IsIncomeTax { get; set; }

        /// <summary>
        /// Gets or sets Id of issued tax document.
        /// </summary>
        public int? IssuedTaxDocumentId { get; set; }

        /// <summary>
        /// Gets or sets bank statement items.
        /// </summary>
        public List<BankStatementItemListGetModel> Items { get; set; }

        /// <summary>
        /// Gets or sets additional information about the entity.
        /// </summary>
        public Metadata Metadata { get; set; }

        /// <summary>
        /// Gets or sets Paired document.
        /// </summary>
        public PairedDocumentGetModel PairedDocument { get; set; }

        /// <summary>
        /// Gets or sets The movement type.
        /// </summary>
        public MovementType MovementType { get; set; }

        /// <summary>
        /// Gets or sets numeric sequence id.
        /// </summary>
        public int NumericSequenceId { get; set; }

        /// <summary>
        /// Gets or sets Account number.
        /// </summary>
        public string PartnerAccountNumber { get; set; }

        /// <summary>
        /// Gets or sets Four character bank code.
        /// </summary>
        public string PartnerBankCode { get; set; }

        /// <summary>
        /// Gets or sets IBAN.
        /// </summary>
        public string PartnerIban { get; set; }

        /// <summary>
        /// Gets or sets Swift code.
        /// </summary>
        public string PartnerSwift { get; set; }

        /// <summary>
        /// Gets or sets Id of the partner's contact.
        /// </summary>
        public int? PartnerId { get; set; }

        /// <summary>
        /// Gets or sets Partner name.
        /// </summary>
        public string PartnerName { get; set; }

        /// <summary>
        /// Gets or sets All recounted prices.
        /// </summary>
        public Prices Prices { get; set; }

        /// <summary>
        /// Gets or sets start date of the statement.
        /// </summary>
        [Obsolete]
        public DateTime PeriodDateFrom { get; set; }

        /// <summary>
        /// Gets or sets end date of the statement.
        /// </summary>
        [Obsolete]
        public DateTime PeriodDateTo { get; set; }

        /// <summary>
        /// Gets or sets Specific symbol.
        /// </summary>
        public string SpecificSymbol { get; set; }

        /// <summary>
        /// Gets or sets Status.
        /// </summary>
        public BankStatementPairingStatus Status { get; set; }

        /// <summary>
        /// Gets or sets tags.
        /// </summary>
        public List<TagDocumentListGetModel> Tags { get; set; }

        /// <summary>
        /// Gets or sets Variable symbol.
        /// </summary>
        public string VariableSymbol { get; set; }

        /// <summary>
        /// Gets or sets VAT regime.
        /// </summary>
        public VatRegime VatRegime { get; set; }
    }
}
