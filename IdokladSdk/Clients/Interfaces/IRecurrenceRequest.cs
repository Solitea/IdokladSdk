using System.Threading;
using System.Threading.Tasks;
using IdokladSdk.Response;

namespace IdokladSdk.Clients.Interfaces
{
    /// <summary>
    /// Interface for recurrence endpoints.
    /// </summary>
    /// <typeparam name="TGetModel">Get model type.</typeparam> name=""/>
    public interface IRecurrenceRequest<TGetModel>
    {
        /// <summary>
        /// Method returns model for recurring invoice generated from issued invoice. Returned resource is suitable for new invoice creation.
        /// </summary>
        /// <param name="id">Invoice Id.</param>
        /// <returns>Resource of recurring invoice for creation.</returns>
        ApiResult<TGetModel> Recurrence(int id);

        /// <summary>
        /// Method returns model for recurring invoice generated from issued invoice. Returned resource is suitable for new invoice creation.
        /// </summary>
        /// <param name="id">Invoice Id.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns>Resource of recurring invoice for creation.</returns>
        Task<ApiResult<TGetModel>> RecurrenceAsync(int id, CancellationToken cancellationToken = default);
    }
}
