using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Net.Http;
using IdokladSdk.Builders;
using IdokladSdk.Enums;
using IdokladSdk.IntegrationTests.Core;
using IdokladSdk.Models.Batch;
using IdokladSdk.Response;
using NUnit.Framework;

namespace IdokladSdk.IntegrationTests.Tests.Features.Validation
{
    [TestFixture]
    public class ApiResultValidatorTests : TestBase
    {
        private const int NotFoundIssuedInvoiceId = -1;

        [OneTimeSetUp]
        public void OneTimeSetup()
        {
            HttpClient = new HttpClient();
            InitDokladApi(ApiResultHandler, ApiBatchResultHandler);

            void ApiResultHandler(ApiResult apiresult)
            {
                if (!apiresult.IsSuccess)
                {
                    throw new ArgumentException("Unsuccessfull response."); // any exception
                }
            }

            void ApiBatchResultHandler(ApiBatchResult apiBatchResult)
            {
                if (apiBatchResult.Status == BatchResultType.Failure)
                {
                    throw new ArgumentException("Unsuccessfull response."); // any exception
                }

                if (apiBatchResult.Status == BatchResultType.PartialSuccess)
                {
                    throw new ArgumentException("Unsuccessfull partial response."); // any exception
                }
            }
        }

        [Test]
        public void InvalidConfiguration_ThrowsException()
        {
            var invalidApiUrl = Configuration.Urls.ApiUrl + "/dev/v3";
            var api = new DokladApiBuilder("Tests", "1.0")
                .AddClientCredentialsAuthentication(Configuration.ClientCredentials.ClientId, Configuration.ClientCredentials.ClientSecret, Configuration.ClientCredentials.ApplicationId)
                .AddCustomApiUrls(invalidApiUrl, Configuration.Urls.IdentityServerUrl)
                .AddHttpClient(HttpClient)
                .Build();

            Assert.ThrowsAsync<ValidationException>(async () => await api.ContactClient.List().GetAsync());
        }

        [Test]
        public void ApiResult_CallsHandler_ThrowsExceptionAsync()
        {
            // Arrange
            var issuedInvoiceClient = DokladApi.IssuedInvoiceClient;

            // Assert
            Assert.ThrowsAsync<ArgumentException>(async () => await issuedInvoiceClient.DeleteAsync(NotFoundIssuedInvoiceId));
        }

        [Test]
        public void ApiBatchResult_CallsHandler_ThrowsExceptionAsync()
        {
            // Arrange
            var batchClient = DokladApi.BatchClient;
            var modelsToUpdate = new List<UpdateExportedModel>()
        {
            new UpdateExportedModel
            {
                Id = -1,
                EntityType = ExportableEntityType.Contact,
                Exported = ExportedState.Exported
            },
            new UpdateExportedModel
            {
                Id = -1,
                EntityType = ExportableEntityType.CreditNote,
                Exported = ExportedState.NotExported
            }
        };

            // Assert
            Assert.ThrowsAsync<ArgumentException>(async () => await batchClient.UpdateAsync(modelsToUpdate));
        }
    }
}
