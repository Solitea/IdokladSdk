using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using IdokladSdk.Enums;
using IdokladSdk.Exceptions;
using IdokladSdk.Response;
using IdokladSdk.Serialization;
using IdokladSdk.UnitTests.Tests.Validation.Exceptions;
using IdokladSdk.Validation;
using Newtonsoft.Json;
using NUnit.Framework;

namespace IdokladSdk.UnitTests.Tests.Validation
{
    [TestFixture]
    public class ApiResultValidatorTests
    {
        [Test]
        public void ApiResult_BasicSchema_Valid()
        {
            // Arrange
            var response = new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent(JsonConvert.SerializeObject(GetDefaultApiResult()))
            };

            // Assert
            Assert.DoesNotThrowAsync(async () =>
                    await ApiResultValidator.ValidateAndDeserializeResponse(response, GetDataAsync<ApiResult<bool>>, null));
        }

        [Test]
        public void ApiBatchResult_BatchSchema_Valid()
        {
            // Arrange
            var response = new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent(JsonConvert.SerializeObject(GetDefaultApiBatchResult()))
            };

            // Assert
            Assert.DoesNotThrowAsync(async () =>
                    await ApiResultValidator.ValidateAndDeserializeResponse(response, GetDataAsync<ApiBatchResult<bool>>, null));
        }

        [Test]
        public void ApiResult_InvokeHandler_ThrowsException()
        {
            // Arrange
            var response = new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent(JsonConvert.SerializeObject(GetDefaultApiResult()))
            };

            // Assert
            Assert.ThrowsAsync<CustomTestException>(async () =>
                    await ApiResultValidator.ValidateAndDeserializeResponse(response, GetDataAsync<ApiResult<bool>>, ApiResultHandler));

            void ApiResultHandler(ApiResult apiResult)
            {
                if (!apiResult.IsSuccess)
                {
                    throw new CustomTestException();
                }
            }
        }

        [Test]
        public void ApiBatchResult_InvokeHandler_ThrowsException()
        {
            // Arrange
            var response = new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent(JsonConvert.SerializeObject(GetDefaultApiBatchResult()))
            };

            // Assert
            Assert.ThrowsAsync<CustomTestException>(async () =>
                    await ApiResultValidator.ValidateAndDeserializeResponse(response, GetDataAsync<ApiBatchResult<bool>>, ApiBatchResultHandler));

            void ApiBatchResultHandler(ApiBatchResult apiResult)
            {
                if (apiResult.Status == BatchResultType.Failure)
                {
                    throw new CustomTestException();
                }
            }
        }

        [Test]
        public void ApiResult_ServiceUnavailabe_Throws()
        {
            // Arrange
            var response = new HttpResponseMessage(HttpStatusCode.ServiceUnavailable);

            // Assert
            Assert.Throws<IdokladUnavailableException>(() => ApiResultValidator.ValidateResponse(response));
        }

        [Test]
        public void ApiBatchResult_ServiceUnavailabe_Throws()
        {
            // Arrange
            var response = new HttpResponseMessage(HttpStatusCode.ServiceUnavailable);

            // Assert
            Assert.Throws<IdokladUnavailableException>(() => ApiResultValidator.ValidateResponse(response));
        }

        private async Task<T> GetDataAsync<T>(HttpResponseMessage response)
        {
            var content = await response.Content.ReadAsStringAsync();
            var data = JsonConvert.DeserializeObject<T>(content, new CommonJsonSerializerSettings());

            return data;
        }

        private ApiBatchResult<bool> GetDefaultApiBatchResult()
        {
            return new ApiBatchResult<bool>
            {
                Results = new List<ApiResult<bool>> { GetDefaultApiResult() }
            };
        }

        private ApiResult<bool> GetDefaultApiResult()
        {
            return new ApiResult<bool> { Message = string.Empty };
        }
    }
}
