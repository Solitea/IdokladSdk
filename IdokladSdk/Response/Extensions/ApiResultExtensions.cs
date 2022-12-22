using System.Threading.Tasks;
using IdokladSdk.Exceptions;

namespace IdokladSdk.Response.Extensions
{
    /// <summary>
    /// ApiResult extensions.
    /// </summary>
    public static class ApiResultExtensions
    {
        /// <summary>
        /// Checks API response and returns data if operation was successful; otherwise throws an exception.
        /// </summary>
        /// <typeparam name="TData">Data type.</typeparam>
        /// <param name="apiResult">Api result.</param>
        /// <returns>Data from API.</returns>
        /// <exception cref="IdokladSdkException">Throws, if result is not successfull.</exception>
        public static async Task<TData> CheckResult<TData>(this Task<ApiResult<TData>> apiResult)
        {
            var result = await apiResult.ConfigureAwait(false);

            if (!result.IsSuccess)
            {
                throw new IdokladSdkException(result);
            }

            return result.Data;
        }
    }
}
