using System;
using System.Threading;
using System.Threading.Tasks;
using IdokladSdk.Models.Account;
using IdokladSdk.Response;
using RestSharp;

namespace IdokladSdk.Requests.Account.Agenda
{
    public partial class Agendas
    {
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
        /// Request to delete the agenda. Deletion of the agenda has to be confirmed by clicking on the link in the email.
        /// </summary>
        /// <param name="model">Reasons for deleting the agenda.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns><c>true</c>.</returns>
        public Task<ApiResult<bool>> DeleteRequestAsync(AgendaDeleteRequestPostModel model, CancellationToken cancellationToken = default)
        {
            return _client.PostAsync<AgendaDeleteRequestPostModel, bool>(DeleteRequestUrl, model, cancellationToken);
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

        /// <inheritdoc />
        public Task<ApiResult<AgendaGetModel>> UpdateAsync(AgendaPatchModel model, CancellationToken cancellationToken = default)
        {
            return _client.PatchAsync<AgendaPatchModel, AgendaGetModel>(CurrentAgendaUrl, model, cancellationToken);
        }

        /// <summary>
        /// Sets agenda logo. Existing logo will be replaced. Optimal size is 280 x 100 (96 DPI) or 900 x 300 (300 DPI). Max. file size is 5 MB.
        /// </summary>
        /// <param name="model">New logo.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns>Agenda's logo.</returns>
        public async Task<ApiResult<bool>> UploadLogoAsync(LogoPostModel model, CancellationToken cancellationToken = default)
        {
            if (model is null)
            {
                throw new ArgumentNullException(nameof(model));
            }

            var request = await _client.CreateRequestAsync(LogoUrl, Method.PUT, cancellationToken).ConfigureAwait(false);
            request.AddFile(model.FileName, model.FileBytes, model.FileName);
            request.AlwaysMultipartFormData = true;
            return await _client.ExecuteAsync<bool>(request, cancellationToken).ConfigureAwait(false);
        }
    }
}
