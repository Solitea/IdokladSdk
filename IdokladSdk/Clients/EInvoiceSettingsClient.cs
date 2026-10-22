using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using IdokladSdk.Models.EInvoiceSettings;
using IdokladSdk.Response;

namespace IdokladSdk.Clients
{
    /// <summary>
    /// Client for electronic invoice settings. Available only for Slovak legislation.
    /// </summary>
    public class EInvoiceSettingsClient : BaseClient
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="EInvoiceSettingsClient"/> class.
        /// </summary>
        /// <param name="apiContext">API context.</param>
        public EInvoiceSettingsClient(ApiContext apiContext)
            : base(apiContext)
        {
        }

        /// <inheritdoc />
        public override string ResourceUrl { get; } = "/EInvoiceSettings";

        /// <summary>
        /// Gets all electronic invoice settings for the current agenda.
        /// </summary>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns>Electronic invoice settings.</returns>
        public Task<ApiResult<List<EInvoiceSettingsGetModel>>> GetAsync(CancellationToken cancellationToken = default)
        {
            return GetAsync<List<EInvoiceSettingsGetModel>>(ResourceUrl, null, cancellationToken);
        }

        /// <summary>
        /// Creates electronic invoice settings.
        /// </summary>
        /// <param name="model">Settings to create.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns>Operation result.</returns>
        public Task<ApiResult<bool>> PostAsync(EInvoiceSettingsPostModel model, CancellationToken cancellationToken = default)
        {
            return PostAsync<EInvoiceSettingsPostModel, bool>(model, cancellationToken);
        }

        /// <summary>
        /// Updates electronic invoice settings.
        /// </summary>
        /// <param name="model">Settings to update.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns>Operation result.</returns>
        public Task<ApiResult<bool>> UpdateAsync(EInvoiceSettingsPatchModel model, CancellationToken cancellationToken = default)
        {
            return PatchAsync<EInvoiceSettingsPatchModel, bool>(model, cancellationToken);
        }

        /// <summary>
        /// Deletes electronic invoice settings.
        /// </summary>
        /// <param name="id">Settings identifier.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns>Operation result.</returns>
        public Task<ApiResult<bool>> DeleteAsync(int id, CancellationToken cancellationToken = default)
        {
            return DeleteAsync<bool>(id, cancellationToken);
        }
    }
}
