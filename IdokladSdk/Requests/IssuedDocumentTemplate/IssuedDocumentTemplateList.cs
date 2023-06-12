using IdokladSdk.Clients;
using IdokladSdk.Models.IssuedDocumentTemplate.List;
using IdokladSdk.Requests.Core;
using IdokladSdk.Requests.IssuedDocumentTemplate.Filter;
using IdokladSdk.Requests.IssuedDocumentTemplate.Sort;

namespace IdokladSdk.Requests.IssuedDocumentTemplate
{
    /// <summary>
    /// List of issued document template.
    /// </summary>
    public class IssuedDocumentTemplateList : BaseList<IssuedDocumentTemplateList, IssuedDocumentTemplateClient, IssuedDocumentTemplateListGetModel, IssuedDocumentTemplateFilter, IssuedDocumentTemplateSort>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="IssuedDocumentTemplateList"/> class.
        /// </summary>
        /// <param name="client">Client.</param>
        public IssuedDocumentTemplateList(IssuedDocumentTemplateClient client)
            : base(client)
        {
        }
    }
}
