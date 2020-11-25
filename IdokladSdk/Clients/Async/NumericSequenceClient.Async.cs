using System;
using System.Threading;
using System.Threading.Tasks;
using IdokladSdk.Enums;
using IdokladSdk.Models.NumericSequence;
using IdokladSdk.Response;

namespace IdokladSdk.Clients
{
    public partial class NumericSequenceClient
    {
        /// <summary>
        /// Returns document number and variable symbol by parameters.
        /// </summary>
        /// <param name="documentType">Document type.</param>
        /// <param name="date">Date.</param>
        /// <param name="documentSerialNumber">Serial number.</param>
        /// <param name="numericSequenceId">Numeric sequence id.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns><see cref="ApiResult{TData}"/> instance containing <see cref="DocumentNumbersGetModel"/>.</returns>
        public Task<ApiResult<DocumentNumbersGetModel>> GetDocumentNumberAsync(NumericSequenceDocumentType documentType,  DateTime? date = null, int? documentSerialNumber = null, int? numericSequenceId = null, CancellationToken cancellationToken = default)
        {
            var resource = $"{ResourceUrl}/DocumentNumbers/{documentType}";
            var queryParams = QueryParams(date, documentSerialNumber, numericSequenceId);
            return GetAsync<DocumentNumbersGetModel>(resource, queryParams, cancellationToken);
        }

        /// <inheritdoc />
        public Task<ApiResult<NumericSequenceGetModel>> UpdateAsync(NumericSequencePatchModel model, CancellationToken cancellationToken = default)
        {
            return PatchAsync<NumericSequencePatchModel, NumericSequenceGetModel>(model, cancellationToken);
        }
    }
}
