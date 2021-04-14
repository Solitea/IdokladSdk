using System;
using IdokladSdk.Clients;
using IdokladSdk.Clients.Interfaces;
using IdokladSdk.Models.Account;
using IdokladSdk.Response;
using IdokladSdk.Validation;
using RestSharp;

namespace IdokladSdk.Requests.Account.Agenda
{
    /// <summary>
    /// Agenda.
    /// </summary>
    public partial class Agendas :
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

        private string DeleteRequestUrl => $"{_client.ResourceUrl}/Agendas/DeleteRequest";

        private string GenerateBankStatementMailUrl => $"{CurrentAgendaUrl}/GenerateBankStatementMail";

        private string LogoUrl => $"{CurrentAgendaUrl}/Logo";

        private string CurrentAgendaUrl => $"{_client.ResourceUrl}/CurrentAgenda";

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
        /// <returns><c>true</c>.</returns>
        public ApiResult<bool> DeleteLogo()
        {
            return _client.Delete<bool>(LogoUrl);
        }

        /// <summary>
        /// Request to delete the agenda. Deletion of the agenda has to be confirmed by clicking on the link in the email.
        /// </summary>
        /// <param name="model">Reasons for deleting the agenda.</param>
        /// <returns><c>true</c>.</returns>
        public ApiResult<bool> DeleteRequest(AgendaDeleteRequestPostModel model)
        {
            return _client.Post<AgendaDeleteRequestPostModel, bool>(DeleteRequestUrl, model);
        }

        /// <inheritdoc/>
        public AgendaDetail Detail(int id)
        {
            return new AgendaDetail(id, _client);
        }

        /// <summary>
        /// Generation of an e-mail address to which the bank will send bank movements messages.
        /// </summary>
        /// <returns>E-mail address.</returns>
        public ApiResult<string> GenerateBankStatementMail()
        {
            return _client.Post<string>(GenerateBankStatementMailUrl);
        }

        /// <summary>
        /// Returns agenda's logo.
        /// </summary>
        /// <returns>Agenda's logo.</returns>
        public ApiResult<LogoGetModel> GetLogo()
        {
            return _client.Get<LogoGetModel>(LogoUrl);
        }

        /// <inheritdoc/>
        public AgendaList List()
        {
            return new AgendaList(_client);
        }

        /// <inheritdoc />
        public ApiResult<AgendaGetModel> Update(AgendaPatchModel model)
        {
            AgendaValidator.ValidatePatch(model);
            return _client.Patch<AgendaPatchModel, AgendaGetModel>(CurrentAgendaUrl, model);
        }

        /// <summary>
        /// Sets agenda logo. Existing logo will be replaced. Optimal size is 280 x 100 (96 DPI) or 900 x 300 (300 DPI). Max. file size is 5 MB.
        /// </summary>
       /// <param name="model">New logo.</param>
       /// <returns><c>true</c>.</returns>
        public ApiResult<bool> UploadLogo(LogoPostModel model)
        {
            if (model is null)
            {
                throw new ArgumentNullException(nameof(model));
            }

            var request = _client.CreateRequest(LogoUrl, Method.PUT);
            request.AddFile(model.FileName, model.FileBytes, model.FileName);
            request.AlwaysMultipartFormData = true;
            return _client.Execute<bool>(request);
        }
    }
}
