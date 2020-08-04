using IdokladSdk.Models.Contact;
using IdokladSdk.Requests.Core.Modifiers.Sort.BasicSorts;
using IdokladSdk.Requests.Core.Modifiers.Sort.Common;

namespace IdokladSdk.Requests.Contact.Sort
{
    /// <summary>
    /// Sortable properties of <see cref="ContactListGetModel"/>.
    /// </summary>
    public class ContactSort : IdSort
    {
        /// <inheritdoc cref="ContactListGetModel.CompanyName"/>
        public SortItem CompanyName { get; set; } = new SortItem(nameof(ContactListGetModel.CompanyName));
    }
}
