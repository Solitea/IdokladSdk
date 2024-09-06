using System.Threading;
using IdokladSdk.Enums;
using IdokladSdk.Requests.Core;
using IdokladSdk.Requests.UnpairedDocument;

namespace IdokladSdk.Clients
{
    /// <summary>
    /// Client for communication with unpaired document endpoints.
    /// </summary>
    public class UnpairedDocumentClient : BaseClient
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UnpairedDocumentClient"/> class.
        /// </summary>
        /// <param name="apiContext">API context.</param>
        public UnpairedDocumentClient(ApiContext apiContext)
            : base(apiContext)
        {
        }

        /// <inheritdoc />
        public override string ResourceUrl => "/UnpairedDocuments";

        /// <summary>
        /// List of unpaired document. Returns an instance which allows operations on a list of documents (filtering, sorting, etc.)
        /// and retrieving data by calling <see cref="BaseList{TList,TClient,TGetModel,TFilter,TSort}.GetAsync(CancellationToken)"/>.
        /// </summary>
        /// <param name="movementType">Movement type.</param>
        /// <returns>Instance of descendant of <see cref="BaseList{TList,TClient,TGetModel,TFilter,TSort}"/>.</returns>
        public UnpairedDocumentList List(MovementType movementType)
        {
            return new UnpairedDocumentList(this, movementType);
        }
    }
}
