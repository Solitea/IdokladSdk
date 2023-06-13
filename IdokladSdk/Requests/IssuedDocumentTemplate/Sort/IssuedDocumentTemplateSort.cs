using IdokladSdk.Models.Contact;
using IdokladSdk.Models.IssuedDocumentTemplate.List;
using IdokladSdk.Requests.Core.Modifiers.Sort.BasicSorts;
using IdokladSdk.Requests.Core.Modifiers.Sort.Common;

namespace IdokladSdk.Requests.IssuedDocumentTemplate.Sort
{
    /// <summary>
    /// IssuedDocumentTemplateSort.
    /// </summary>
    public class IssuedDocumentTemplateSort : IdSort
    {
        /// <inheritdoc cref="ContactListGetModel.CompanyName"/>
        public SortItem CompanyName { get; set; } =
            new SortItem(nameof(IssuedDocumentTemplateListGetModel.Partner.CompanyName));

        /// <inheritdoc cref="IssuedDocumentTemplateListGetModel.Name"/>
        public SortItem Name { get; set; } = new SortItem(nameof(IssuedDocumentTemplateListGetModel.Name));
    }
}
