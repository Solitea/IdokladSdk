using IdokladSdk.Models.DocumentAddress;
using IdokladSdk.Models.SalesPosEquipment;
using IdokladSdk.Models.SalesReceipt;
using IdokladSdk.Requests.Core.Modifiers.Sort.BasicSorts;
using IdokladSdk.Requests.Core.Modifiers.Sort.Common;

namespace IdokladSdk.Requests.SalesReceipt.Sort
{
    /// <summary>
    /// Sortable properties of <see cref="SalesReceiptListGetModel"/>.
    /// </summary>
    public class SalesReceiptSort : IdSort
    {
        /// <inheritdoc cref="SalesReceiptListGetModel.DateOfIssue"/>
        public SortItem DateOfIssue { get; set; } = new SortItem(nameof(SalesReceiptListGetModel.DateOfIssue));

        /// <inheritdoc cref="SalesReceiptListGetModel.DocumentNumber"/>
        public SortItem DocumentNumber { get; set; } = new SortItem(nameof(SalesReceiptListGetModel.DocumentNumber));

        /// <inheritdoc cref="SalesReceiptListGetModel.Name"/>
        public SortItem Name { get; set; } = new SortItem(nameof(SalesReceiptListGetModel.Name));

        /// <inheritdoc cref="DocumentAddressModel.NickName"/>
        public SortItem PartnerName { get; set; } = new SortItem("PartnerName");

        /// <inheritdoc cref="SalesPosEquipmentListGetModel.Designation"/>
        public SortItem SalesPosEquipmentDesignation { get; set; } = new SortItem("SalesPosEquipmentDesignation");
    }
}
