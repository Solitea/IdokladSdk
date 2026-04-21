using IdokladSdk.Clients;
using IdokladSdk.Models.ReceivedDocument.List;
using IdokladSdk.Requests.Core;
using IdokladSdk.Requests.ReceivedDocument.Filter;
using IdokladSdk.Requests.ReceivedDocument.Sort;

namespace IdokladSdk.Requests.ReceivedDocument
{
    /// <summary>
    /// List of received documents.
    /// </summary>
    public class ReceivedDocumentList : BaseList<ReceivedDocumentList, ReceivedDocumentsClient, ReceivedDocumentListGetModel, ReceivedDocumentFilter, ReceivedDocumentSort>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ReceivedDocumentList"/> class.
        /// </summary>
        /// <param name="client">Received documents client.</param>
        public ReceivedDocumentList(ReceivedDocumentsClient client)
            : base(client)
        {
        }
    }
}
