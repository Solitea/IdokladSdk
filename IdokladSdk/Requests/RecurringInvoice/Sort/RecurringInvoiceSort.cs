using IdokladSdk.Models.Contact;
using IdokladSdk.Models.RecurringInvoice;
using IdokladSdk.Requests.Core.Modifiers.Sort.BasicSorts;
using IdokladSdk.Requests.Core.Modifiers.Sort.Common;

namespace IdokladSdk.Requests.RecurringInvoice.Sort
{
    /// <summary>
    /// Sortable properties of <see cref="RecurringInvoiceListGetModel"/>.
    /// </summary>
    public class RecurringInvoiceSort : IdSort
    {
        /// <inheritdoc cref="RecurringSettingListGetModel.TemplateName"/>
        public SortItem TemplateName { get; set; } = new SortItem(nameof(RecurringInvoiceListGetModel.RecurringSetting.TemplateName));

        /// <inheritdoc cref="ContactListGetModel.CompanyName"/>
        public SortItem CompanyName { get; set; } = new SortItem(nameof(ContactGetModel.CompanyName));
    }
}
