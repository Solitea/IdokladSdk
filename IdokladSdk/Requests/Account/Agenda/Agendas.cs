using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using IdokladSdk.Clients;
using IdokladSdk.Clients.Interfaces;
using IdokladSdk.Models.Account;
using IdokladSdk.Response;

namespace IdokladSdk.Requests.Account.Agenda
{
    /// <summary>
    /// Agenda.
    /// </summary>
    public class Agendas :
        IEntityDetail<AgendaDetail>,
        IEntityList<AgendaList>,
        IPatchRequest<AgendaPatchModel, AgendaGetModel>
    {
        private readonly AccountClient _client;

        /// <summary>
        /// Initializes a new instance of the <see cref="Agendas" /> class.
        /// </summary>
        /// <param name="client">Client.</param>
        public Agendas(AccountClient client)
        {
            _client = client;
        }

        private string CurrentAgendaUrl => $"{_client.ResourceUrl}/CurrentAgenda";

        private string DeleteRequestUrl => $"{_client.ResourceUrl}/Agendas/DeleteRequest";

        private string GenerateBankStatementMailUrl => $"{CurrentAgendaUrl}/GenerateBankStatementMail";

        private string LogoUrl => $"{CurrentAgendaUrl}/Logo";

        private string SignatureUrl => $"{CurrentAgendaUrl}/Signature";

        /// <summary>
        /// Current agenda endpoint.
        /// </summary>
        /// <returns>Method return current detail of agenda.</returns>
        public AgendaCurrentDetail Current()
        {
            return new AgendaCurrentDetail(_client);
        }

        /// <summary>
        /// Deletes agenda's logo.
        /// </summary>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns><c>true</c>.</returns>
        public Task<ApiResult<bool>> DeleteLogoAsync(CancellationToken cancellationToken = default)
        {
            return _client.DeleteAsync<bool>(LogoUrl, cancellationToken);
        }

        /// <summary>
        //  Request to delete the agenda. Deletion of the agenda has to be confirmed by clicking on the link in the email.
        /// </summary>
        /// <param name="model">Reasons for deleting the agenda.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns><c>true</c>.</returns>
        public Task<ApiResult<bool>> DeleteRequestAsync(AgendaDeleteRequestPostModel model,
            CancellationToken cancellationToken = default)
        {
            return _client.PostAsync<AgendaDeleteRequestPostModel, bool>(DeleteRequestUrl, model, cancellationToken);
        }

        /// <summary>
        /// Deletes agenda's signature.
        /// </summary>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns><c>true</c>.</returns>
        public Task<ApiResult<bool>> DeleteSignatureAsync(CancellationToken cancellationToken = default)
        {
            return _client.DeleteAsync<bool>(SignatureUrl, cancellationToken);
        }

        /// <inheritdoc />
        public AgendaDetail Detail(int id)
        {
            return new AgendaDetail(id, _client);
        }

        /// <summary>
        /// Generation of an e-mail address to which the bank will send bank movements messages.
        /// </summary>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns>E-mail address.</returns>
        public Task<ApiResult<string>> GenerateBankStatementMailAsync(CancellationToken cancellationToken = default)
        {
            return _client.PostAsync<string>(GenerateBankStatementMailUrl, cancellationToken);
        }

        /// <summary>
        /// Gets agenda's logo.
        /// </summary>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns>Agenda's logo.</returns>
        public Task<ApiResult<LogoGetModel>> GetLogoAsync(CancellationToken cancellationToken = default)
        {
            return _client.GetAsync<LogoGetModel>(LogoUrl, null, cancellationToken);
        }


        /// <summary>
        /// Gets agenda's signature.
        /// </summary>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns>Agenda's signature.</returns>
        public Task<ApiResult<SignatureGetModel>> GetSignatureAsync(CancellationToken cancellationToken = default)
        {
            return _client.GetAsync<SignatureGetModel>(SignatureUrl, null, cancellationToken);
        }

        /// <inheritdoc />
        public AgendaList List()
        {
            return new AgendaList(_client);
        }

        /// <inheritdoc />
        public Task<ApiResult<AgendaGetModel>> UpdateAsync(AgendaPatchModel model,
            CancellationToken cancellationToken = default)
        {
            return _client.PatchAsync<AgendaPatchModel, AgendaGetModel>(CurrentAgendaUrl, model, cancellationToken);
        }

        /// <summary>
        /// Sets agenda logo. Existing logo will be replaced. Optimal size is 280 x 100 (96 DPI) or 900 x 300 (300 DPI). Max.file size is 5 MB.
        /// </summary>
        /// <param name="model">New logo.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns><c>true</c></returns>
        public async Task<ApiResult<bool>> UploadLogoAsync(LogoPostModel model,
            CancellationToken cancellationToken = default)
        {
            if (model is null)
            {
                throw new ArgumentNullException(nameof(model));
            }

            var queryParams = new Dictionary<string, string> { { "highResolution", model.HighResolution.ToString() } };

            return await _client.PutFileAsync<bool>(LogoUrl, model, queryParams, cancellationToken)
                .ConfigureAwait(false);
        }

        /// <summary>
        /// Sets agenda signature. Existing signature will be replaced. Max. file size is 5 MB.
        /// </summary>
        /// <param name="model">New signature.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns><c>true</c></returns>
        public async Task<ApiResult<bool>> UploadSignatureAsync(SignaturePostModel model,
            CancellationToken cancellationToken = default)
        {
            if (model is null)
            {
                throw new ArgumentNullException(nameof(model));
            }

            return await _client.PutFileAsync<bool>(SignatureUrl, model, null, cancellationToken).ConfigureAwait(false);
        }
    }
}
