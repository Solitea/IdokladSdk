using System;
using IdokladSdk.Enums;
using IdokladSdk.Models.RegisteredSale;
using IdokladSdk.Requests.Core.Modifiers.Filters;
using IdokladSdk.Requests.Core.Modifiers.Filters.Common;

namespace IdokladSdk.Requests.RegisteredSale.Filter
{
    /// <summary>
    /// Filterable properties of <see cref="RegisteredSaleListGetModel"/>.
    /// </summary>
    public class RegisteredSaleFilter : IdFilter
    {
        /// <inheritdoc cref="RegisteredSaleListGetModel.SalesReceiptId"/>
        public NullableContainIdFilterItem SalesReceiptId { get; set; } = new NullableContainIdFilterItem(nameof(RegisteredSaleListGetModel.SalesReceiptId));

        /// <inheritdoc cref="RegisteredSaleListGetModel.CashVoucherId"/>
        public NullableContainIdFilterItem CashVoucherId { get; set; } = new NullableContainIdFilterItem(nameof(RegisteredSaleListGetModel.CashVoucherId));

        /// <inheritdoc cref="RegisteredSaleListGetModel.IssuedInvoiceId"/>
        public NullableContainIdFilterItem IssuedInvoiceId { get; set; } = new NullableContainIdFilterItem(nameof(RegisteredSaleListGetModel.IssuedInvoiceId));

        /// <inheritdoc cref="RegisteredSaleListGetModel.IssuedInvoicePaymentId"/>
        public NullableContainIdFilterItem IssuedInvoicePaymentId { get; set; } = new NullableContainIdFilterItem(nameof(RegisteredSaleListGetModel.IssuedInvoicePaymentId));

        /// <inheritdoc cref="RegisteredSaleListGetModel.SalesPosEquipmentId"/>
        public NullableContainIdFilterItem SalesPosEquipmentId { get; set; } = new NullableContainIdFilterItem(nameof(RegisteredSaleListGetModel.SalesPosEquipmentId));

        /// <inheritdoc cref="RegisteredSaleListGetModel.DocumentType"/>
        public FilterItem<DocumentType> DocumentType { get; set; } = new FilterItem<DocumentType>(nameof(RegisteredSaleListGetModel.DocumentType));

        /// <inheritdoc cref="RegisteredSaleListGetModel.DocumentNumber"/>
        public ContainFilterItem<string> DocumentNumber { get; set; } = new ContainFilterItem<string>(nameof(RegisteredSaleListGetModel.DocumentNumber));

        /// <inheritdoc cref="RegisteredSaleListGetModel.DateOfSale"/>
        public CompareFilterItem<DateTime> DateOfSale { get; set; } = new CompareFilterItem<DateTime>(nameof(RegisteredSaleListGetModel.DateOfSale));
    }
}
