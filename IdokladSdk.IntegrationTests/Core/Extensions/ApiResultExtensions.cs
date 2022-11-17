using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using IdokladSdk.Enums;
using IdokladSdk.Response;
using NUnit.Framework;

namespace IdokladSdk.IntegrationTests.Core.Extensions;

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

    public static async Task<T> AssertResult<T>(this Task<ApiResult<T>> result)
    {
        var response = await result;

        Assert.IsInstanceOf<ApiResult<T>>(response);
        Assert.IsTrue(response.IsSuccess, response.Message);
        Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
        Assert.NotNull(response.Data);
        return response.Data;
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

    /// <summary>
    /// Assert result.
    /// </summary>
    /// <param name="batchResult">Result.</param>
    /// <typeparam name="T">T.</typeparam>
    /// <returns>Method assert result.</returns>
    public static async Task<IEnumerable<T>> AssertResult<T>(this Task<ApiBatchResult<T>> batchResult)
    {
        var result = await batchResult;
        Assert.IsInstanceOf<ApiBatchResult<T>>(result);
        Assert.AreEqual(result.Status, BatchResultType.Success);

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
