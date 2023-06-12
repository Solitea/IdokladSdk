using IdokladSdk.Clients;
using IdokladSdk.Models.IssuedDocumentTemplate.Get;
using IdokladSdk.Requests.Core;
using IdokladSdk.Requests.Core.Modifiers.Expand.Structure;

namespace IdokladSdk.Requests.IssuedDocumentTemplate
{
    /// <summary>
    /// IssuedDocumentTemplateDetail.
    /// </summary>
    public class IssuedDocumentTemplateDetail :
        ExpandableDetail<IssuedDocumentTemplateDetail, IssuedDocumentTemplateClient, IssuedDocumentTemplateGetModel, IssuedDocumentTemplateExpand>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="IssuedDocumentTemplateDetail"/> class.
        /// Detail template.
        /// </summary>
        /// <param name="id">Id.</param>
        /// <param name="client">Client.</param>
        public IssuedDocumentTemplateDetail(int id, IssuedDocumentTemplateClient client)
            : base(id, client)
        {
        }
    }
}
