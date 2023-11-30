using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using IdokladSdk.Enums;
using IdokladSdk.Response;
using NUnit.Framework;

namespace IdokladSdk.IntegrationTests.Core.Extensions
{
    /// <summary>
    /// ApiResultExtensions.
    /// </summary>
    public static class ApiResultExtensions
    {
        /// <summary>
        /// Assert result.
        /// </summary>
        /// <param name="result">Result.</param>
        /// <typeparam name="T">T.</typeparam>
        /// <returns>Method assert result.</returns>
        public static T AssertResult<T>(this ApiResult<T> result)
        {
            Assert.That(result, Is.InstanceOf<ApiResult<T>>());
            Assert.That(result.IsSuccess, Is.True, result.Message);
            Assert.That(result.StatusCode, Is.EqualTo(HttpStatusCode.OK));
            Assert.That(result.Data, Is.Not.Null);
            return result.Data;
        }

        /// <summary>
        /// Assert result.
        /// </summary>
        /// <param name="result">Result.</param>
        /// <typeparam name="T">T.</typeparam>
        /// <returns>Method assert result.</returns>
        public static async Task<T> AssertResult<T>(this Task<ApiResult<T>> result)
        {
            var response = await result;

            Assert.That(response, Is.InstanceOf<ApiResult<T>>());
            Assert.That(response.IsSuccess, Is.True, response.Message);
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
            Assert.That(response.Data, Is.Not.Null);
            return response.Data;
        }

        /// <summary>
        /// Assert result.
        /// </summary>
        /// <param name="batchResult">Result.</param>
        /// <typeparam name="T">T.</typeparam>
        /// <returns>Method assert result.</returns>
        public static async Task<IEnumerable<T>> AssertResult<T>(this Task<ApiBatchResult<T>> batchResult)
        {
            var result = await batchResult;
            Assert.That(result, Is.InstanceOf<ApiBatchResult<T>>());
            Assert.That(result.Status, Is.EqualTo(BatchResultType.Success));

            Assert.Multiple(() =>
            {
                foreach (var result in result.Results)
                {
                    result.AssertResult();
                }
            });

            return result.Results.Select(x => x.Data);
        }
    }
}
