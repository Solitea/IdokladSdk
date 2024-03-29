﻿using System.Threading;
using System.Threading.Tasks;
using IdokladSdk.Response;

namespace IdokladSdk.Clients.Interfaces
{
    /// <summary>
    /// Interface for FullyUnpay endpoints.
    /// </summary>
    public interface IFullyUnpayRequest
    {
        /// <summary>
        /// Fully unpays document.
        /// </summary>
        /// <param name="invoiceId">Id of invoice.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns><c>true</c> if full unpay was successful, otherwise <c>false</c>.</returns>
        Task<ApiResult<bool>> FullyUnpayAsync(int invoiceId, CancellationToken cancellationToken = default);
    }
}
