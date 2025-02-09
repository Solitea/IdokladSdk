﻿using IdokladSdk.Requests.Core.Modifiers.Expand.Common;

namespace IdokladSdk.Requests.Core.Modifiers.Expand.Structure
{
    /// <summary>
    /// IssuedInvoiceExpand.
    /// </summary>
    public class IssuedInvoiceExpand : ExpandableEntity
    {
        /// <summary>
        /// Gets or sets constantSymbol.
        /// </summary>
        public ConstantSymbolExpand ConstantSymbol { get; set; }

        /// <summary>
        /// Gets or sets currency.
        /// </summary>
        public CurrencyExpand Currency { get; set; }

        /// <summary>
        /// Gets or sets tags.
        /// </summary>
        public IssuedInvoiceItemExpand Items { get; set; }

        /// <summary>
        /// Gets or sets partner.
        /// </summary>
        public ContactExpand Partner { get; set; }

        /// <summary>
        /// Gets or sets paymentOption.
        /// </summary>
        public PaymentOptionExpand PaymentOption { get; set; }

        /// <summary>
        /// Gets or sets salesPosEquipment.
        /// </summary>
        public SalesPosEquipmentExpand SalesPosEquipment { get; set; }

        /// <summary>
        /// Gets or sets tags.
        /// </summary>
        public TagsExpand Tags { get; set; }

        /// <summary>
        /// Gets or sets vatReverseChargeCode.
        /// </summary>
        public VatReverseChargeCodeExpand VatReverseChargeCode { get; set; }
    }
}
