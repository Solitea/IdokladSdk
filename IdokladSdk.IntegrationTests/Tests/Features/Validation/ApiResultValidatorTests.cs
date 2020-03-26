using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using IdokladSdk.Enums;
using IdokladSdk.IntegrationTests.Core;
using IdokladSdk.IntegrationTests.Core.AuthProviders;
using IdokladSdk.Models.Batch;
using IdokladSdk.Response;
using NUnit.Framework;

namespace IdokladSdk.IntegrationTests.Tests.Features.Validation
{
    [TestFixture]
    public partial class ApiResultValidatorTests : TestBase
    {
        private const int NotFoundIssuedInvoiceId = -1;

        [OneTimeSetUp]
        public void OneTimeSetup()
        {
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
            var auth = new ClientCredentialsAuthProvider().GetAuthentication(Configuration);
            var invalidApiUrl = Configuration.Urls.ApiUrl + "/dev/v3";
            var dokladConfig = new DokladConfiguration(invalidApiUrl, Configuration.Urls.IdentityServerTokenUrl);
            var context = new ApiContext("Tests", "1.0", auth, dokladConfig);
            var api = new DokladApi(context);

            Assert.Throws<ValidationException>(() => api.ContactClient.List().Get());
        }

        [Test]
        public void ApiResult_CallsHandler_ThrowsException()
        {
            // Arrange
            var issuedInvoiceClient = DokladApi.IssuedInvoiceClient;

            // Assert
            Assert.Throws<ArgumentException>(() => issuedInvoiceClient.Delete(NotFoundIssuedInvoiceId));
        }

        [Test]
        public void ApiBatchResult_CallsHandler_ThrowsException()
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
            Assert.Throws<ArgumentException>(() => batchClient.Update(modelsToUpdate));
        }
    }
}
