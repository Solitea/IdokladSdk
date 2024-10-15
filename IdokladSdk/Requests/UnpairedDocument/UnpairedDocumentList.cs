using IdokladSdk.Clients;
using IdokladSdk.Enums;
using IdokladSdk.Models.UnpairedDocument.List;
using IdokladSdk.Requests.Core;
using IdokladSdk.Requests.UnpairedDocument.Filter;
using IdokladSdk.Requests.UnpairedDocument.Sort;

namespace IdokladSdk.Requests.UnpairedDocument
{
    /// <summary>
    /// List of unpaired documents.
    /// </summary>
    public class UnpairedDocumentList : BaseList<UnpairedDocumentList, UnpairedDocumentClient, UnpairedDocumentListGetModel, UnpairedDocumentFilter, UnpairedDocumentSort>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UnpairedDocumentList"/> class.
        /// </summary>
        /// <param name="client">Unpaired document client.</param>
        /// <param name="movementType">Movement type.</param>
        /// <param name="pairingDocumentType">Pairing document type.</param>
        public UnpairedDocumentList(UnpairedDocumentClient client, MovementType movementType, PairingDocumentType pairingDocumentType)
            : base(client)
        {
            ListName = $"{movementType}/{pairingDocumentType}";
        }
    }
}
