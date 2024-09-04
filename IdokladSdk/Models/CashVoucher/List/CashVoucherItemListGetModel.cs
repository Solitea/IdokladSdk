using System;
using IdokladSdk.Enums;
using IdokladSdk.Models.Common;

namespace IdokladSdk.Models.CashVoucher
{
    /// <summary>
    /// Item list model for CashVoucher.
    /// </summary>
    public class CashVoucherItemListGetModel : IEntityId
    {
        /// <summary>
        /// Gets or sets item amount.
        /// </summary>
        [Obsolete]
        public decimal Amount { get; set; }

        /// <summary>
        /// Gets or sets custom VAT rate.
        /// </summary>
        public decimal? CustomVat { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the item has a custom VAT value.
        /// </summary>
        public bool HasCustomVat { get; set; }

        /// <inheritdoc/>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets issued tax document id.
        /// </summary>
        [Obsolete("Moved to Document header")]
        public int? IssuedTaxDocumentId { get; set; }

        /// <summary>
        /// Gets or sets item name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets unit price.
        /// </summary>
        public decimal Price { get; set; }

        /// <summary>
        /// Gets or sets prices and calculations.
        /// </summary>
        public ItemPrices Prices { get; set; }

        /// <summary>
        /// Gets or sets price type.
        /// </summary>
        public PriceTypeWithoutOnlyBase PriceType { get; set; }

        /// <summary>
        /// Gets or sets pairing status.
        /// </summary>
        [Obsolete]
        public CashVoucherDependencyStatus Status { get; set; }

        /// <summary>
        /// Gets or sets VAT classification code.
        /// </summary>
        public int? VatCodeId { get; set; }

        /// <summary>
        /// Gets or sets VAT rate amount.
        /// </summary>
        public decimal VatRate { get; set; }

        /// <summary>
        /// Gets or sets VAT rate type.
        /// </summary>
        public VatRateType VatRateType { get; set; }
    }
}
