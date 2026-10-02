using IdokladSdk.Clients.Interfaces;
using IdokladSdk.Requests.ReceivedDocument;

namespace IdokladSdk.Clients
{
    /// <summary>
    /// Client for communication with received documents endpoints.
    /// </summary>
    public class ReceivedDocumentsClient : BaseClient, IEntityList<ReceivedDocumentList>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ReceivedDocumentsClient"/> class.
        /// </summary>
        /// <param name="apiContext">API context.</param>
        public ReceivedDocumentsClient(ApiContext apiContext)
            : base(apiContext)
        {
        }

        /// <inheritdoc />
        public override string ResourceUrl { get; } = "/ReceivedDocuments";

        /// <inheritdoc />
        public ReceivedDocumentList List()
        {
            return new ReceivedDocumentList(this);
        }
    }
}
