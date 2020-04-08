﻿using IdokladSdk.Models.SalesReceipt;
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
    }
}
