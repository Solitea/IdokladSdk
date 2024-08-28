using IdokladSdk.Enums;
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
        public override string ResourceUrl => "/UnpairedDocument";

        /// <inheritdoc />
        public UnpairedDocumentList List(MovementType movementType)
        {
            return new UnpairedDocumentList(this, movementType);
        }
    }
}
