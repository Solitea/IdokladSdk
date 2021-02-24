using IdokladSdk.Clients;
using IdokladSdk.Models.IssuedTaxDocument.Get;
using IdokladSdk.Requests.Core;
using IdokladSdk.Requests.Core.Modifiers.Expand.Structure;

namespace IdokladSdk.Requests.IssuedTaxDocument
{
    /// <summary>
    /// IssuedTaxDocumentDetail.
    /// </summary>
    public class IssuedTaxDocumentDetail
        : ExpandableDetail<IssuedTaxDocumentDetail, IssuedTaxDocumentClient, IssuedTaxDocumentGetModel, IssuedTaxDocumentExpand>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="IssuedTaxDocumentDetail"/> class.
        /// </summary>
        /// <param name="id">Issued tax document id.</param>
        /// <param name="client">Client.</param>
        public IssuedTaxDocumentDetail(int id, IssuedTaxDocumentClient client)
            : base(id, client)
        {
        }
    }
}
