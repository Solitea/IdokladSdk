using System;
using IdokladSdk.Enums;
using IdokladSdk.Models.RegisteredSale;
using IdokladSdk.Requests.Core.Modifiers.Filters.Common;

namespace IdokladSdk.Requests.RegisteredSale.Filter
{
    /// <summary>
    /// Filterable properties of <see cref=" RegisteredSaleListGetModel"/>.
    /// </summary>
    public class RegisteredSaleFilter
    {
        /// <inheritdoc cref="RegisteredSaleListGetModel.Id"/>
        public CompareFilterItem<int> Id { get; set; } = new CompareFilterItem<int>(nameof(RegisteredSaleListGetModel.Id));

        /// <inheritdoc cref="RegisteredSaleListGetModel.SalesReceiptId"/>
        public FilterItem<int> SalesReceiptId { get; set; } = new FilterItem<int>(nameof(RegisteredSaleListGetModel.SalesReceiptId));

        /// <inheritdoc cref="RegisteredSaleListGetModel.CashVoucherId"/>
        public FilterItem<int> CashVoucherId { get; set; } = new FilterItem<int>(nameof(RegisteredSaleListGetModel.CashVoucherId));

        /// <inheritdoc cref="RegisteredSaleListGetModel.IssuedInvoicePaymentId"/>
        public FilterItem<int> IssuedInvoicePaymentId { get; set; } = new FilterItem<int>(nameof(RegisteredSaleListGetModel.IssuedInvoicePaymentId));

        /// <inheritdoc cref="RegisteredSaleListGetModel.SalesPosEquipmentId"/>
        public FilterItem<int> SalesPosEquipmentId { get; set; } = new FilterItem<int>(nameof(RegisteredSaleListGetModel.SalesPosEquipmentId));

        /// <inheritdoc cref="RegisteredSaleListGetModel.DocumentType"/>
        public FilterItem<DocumentType> DocumentType { get; set; } = new FilterItem<DocumentType>(nameof(RegisteredSaleListGetModel.DocumentType));

        /// <inheritdoc cref="RegisteredSaleListGetModel.DocumentNumber"/>
        public ContainFilterItem<string> DocumentNumber { get; set; } = new ContainFilterItem<string>(nameof(RegisteredSaleListGetModel.DocumentNumber));

        /// <inheritdoc cref="RegisteredSaleListGetModel.DateOfSale"/>
        public CompareFilterItem<DateTime> DateOfSale { get; set; } = new CompareFilterItem<DateTime>(nameof(RegisteredSaleListGetModel.DateOfSale));
    }
}
