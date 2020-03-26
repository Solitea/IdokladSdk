using System.Collections.Generic;
using System.Linq;
using System.Net;
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
            Assert.IsInstanceOf<ApiResult<T>>(result);
            Assert.IsTrue(result.IsSuccess, result.Message);
            Assert.AreEqual(HttpStatusCode.OK, result.StatusCode);
            Assert.NotNull(result.Data);
            return result.Data;
        }

        /// <summary>
        /// Assert result.
        /// </summary>
        /// <param name="batchResult">Result.</param>
        /// <typeparam name="T">T.</typeparam>
        /// <returns>Method assert result.</returns>
        public static IEnumerable<T> AssertResult<T>(this ApiBatchResult<T> batchResult)
        {
            Assert.IsInstanceOf<ApiBatchResult<T>>(batchResult);
            Assert.AreEqual(batchResult.Status, BatchResultType.Success);

            Assert.Multiple(() =>
            {
                foreach (var result in batchResult.Results)
                {
                    result.AssertResult();
                }
            });

            return batchResult.Results.Select(x => x.Data);
        }
    }
}
