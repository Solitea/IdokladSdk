using System;
using System.Collections.Generic;
using System.Globalization;
using System.Threading;
using System.Threading.Tasks;
using IdokladSdk.Enums;
using IdokladSdk.Models.EDocument;
using IdokladSdk.Response;

namespace IdokladSdk.Clients
{
    /// <summary>
    /// Downloads and sends electronic documents. Available only for Slovak legislation.
    /// </summary>
    public class EDocumentClient : BaseClient
    {
        /// <summary>Initializes a new instance of the <see cref="EDocumentClient"/> class.</summary>
        /// <param name="apiContext">API context.</param>
        public EDocumentClient(ApiContext apiContext)
            : base(apiContext)
        {
        }

        /// <inheritdoc/>
        public override string ResourceUrl { get; } = "/EDocuments";

        /// <summary>Downloads XML encoded as Base64. Documents already sent through Peppol return the original XML.</summary>
        /// <param name="id">Document ID.</param>
        /// <param name="documentType">Document type.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns>The Base64 encoded XML document.</returns>
        public Task<ApiResult<string>> DownloadAsync(int id, PeppolDocumentType documentType, CancellationToken cancellationToken = default)
        {
            if (!Enum.IsDefined(typeof(PeppolDocumentType), documentType))
            {
                throw new ArgumentOutOfRangeException(nameof(documentType));
            }

            var queryParams = new Dictionary<string, string>
            {
                { "documentType", ((int)documentType).ToString(CultureInfo.InvariantCulture) }
            };
            return GetAsync<string>($"{ResourceUrl}/{id}/Download", queryParams, cancellationToken);
        }

        /// <summary>Sends an issued electronic invoice.</summary>
        /// <param name="model">Delivery settings.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns>The delivery result.</returns>
        public Task<ApiResult<EInvoiceSendResult>> SendIssuedInvoiceAsync(EInvoiceSendModel model, CancellationToken cancellationToken = default)
        {
            return PostAsync<EInvoiceSendModel, EInvoiceSendResult>($"{ResourceUrl}/IssuedInvoice/Send", model, cancellationToken);
        }

        /// <summary>Sends an electronic credit or debit note.</summary>
        /// <param name="model">Delivery settings.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns>The delivery result.</returns>
        public Task<ApiResult<EInvoiceSendResult>> SendCreditNoteAsync(EInvoiceSendModel model, CancellationToken cancellationToken = default)
        {
            return PostAsync<EInvoiceSendModel, EInvoiceSendResult>($"{ResourceUrl}/CreditNote/Send", model, cancellationToken);
        }

        /// <summary>Sends an issued electronic tax document.</summary>
        /// <param name="model">Delivery settings.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns>The delivery result.</returns>
        public Task<ApiResult<EInvoiceSendResult>> SendIssuedTaxDocumentAsync(EInvoiceSendModel model, CancellationToken cancellationToken = default)
        {
            return PostAsync<EInvoiceSendModel, EInvoiceSendResult>($"{ResourceUrl}/IssuedTaxDocument/Send", model, cancellationToken);
        }
    }
}
