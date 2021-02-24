using IdokladSdk.Clients;
using IdokladSdk.Models.IssuedTaxDocument.List;
using IdokladSdk.Requests.Core;
using IdokladSdk.Requests.Core.Modifiers.Sort.BasicSorts;
using IdokladSdk.Requests.IssuedTaxDocument.Filter;

namespace IdokladSdk.Requests.IssuedTaxDocument
{
    /// <summary>
    /// List of Issued Tax Documents.
    /// </summary>
    public class IssuedTaxDocumentList : BaseList<IssuedTaxDocumentList, IssuedTaxDocumentClient, IssuedTaxDocumentListGetModel, IssuedTaxDocumentFilter, IdSort>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="IssuedTaxDocumentList"/> class.
        /// </summary>
        /// <param name="client">Client.</param>
        public IssuedTaxDocumentList(IssuedTaxDocumentClient client)
            : base(client)
        {
        }
    }
}
