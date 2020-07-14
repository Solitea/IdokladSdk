using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using IdokladSdk.Enums;
using IdokladSdk.Response;
using IdokladSdk.UnitTests.Tests.Validation.Exceptions;
using IdokladSdk.Validation;
using Newtonsoft.Json;
using NUnit.Framework;
using RestSharp;

namespace IdokladSdk.UnitTests.Tests.Validation
{
    [TestFixture]
    public class ApiResultValidatorTests
    {
        [Test]
        public void ApiResult_BasicSchema_Valid()
        {
            // Arrange
            IRestResponse<ApiResult<bool>> response = new RestResponse<ApiResult<bool>>
            {
                Content = JsonConvert.SerializeObject(GetDefaultApiresult())
            };

            // Assert
            Assert.DoesNotThrow(() => ApiResultValidator.ValidateResponse(response, null));
        }

        [Test]
        public void ApiBatchResult_BatchSchema_Valid()
        {
            // Arrange
            IRestResponse<ApiBatchResult<bool>> response = new RestResponse<ApiBatchResult<bool>>
            {
                Content = JsonConvert.SerializeObject(GetDefaultApiBatchResult())
            };

            // Assert
            Assert.DoesNotThrow(() => ApiResultValidator.ValidateResponse(response, null));
        }

        [Test]
        public void ApiResult_InvokeHandler_ThrowsException()
        {
            // Arrange
            IRestResponse<ApiResult<bool>> response = new RestResponse<ApiResult<bool>>
            {
                Content = JsonConvert.SerializeObject(GetDefaultApiresult()),
                Data = GetDefaultApiresult()
            };

            // Assert
            Assert.Throws<CustomTestException>(() => ApiResultValidator.ValidateResponse(response, ApiResultHandler));

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
            IRestResponse<ApiBatchResult<bool>> response = new RestResponse<ApiBatchResult<bool>>
            {
                Content = JsonConvert.SerializeObject(GetDefaultApiBatchResult()),
                Data = GetDefaultApiBatchResult()
            };

            // Assert
            Assert.Throws<CustomTestException>(() => ApiResultValidator.ValidateResponse(response, ApiBatchResultHandler));

            void ApiBatchResultHandler(ApiBatchResult apiResult)
            {
                if (apiResult.Status == BatchResultType.Failure)
                {
                    throw new CustomTestException();
                }
            }
        }

        private ApiBatchResult<bool> GetDefaultApiBatchResult()
        {
            return new ApiBatchResult<bool>
            {
                Results = new List<ApiResult<bool>> { GetDefaultApiresult() }
            };
        }

        private ApiResult<bool> GetDefaultApiresult()
        {
            return new ApiResult<bool> { Message = string.Empty };
        }
    }
}
